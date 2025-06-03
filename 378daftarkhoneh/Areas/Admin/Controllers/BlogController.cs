using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _378daftarkhoneh.Data;
using _378daftarkhoneh.Models;
using System.Text.RegularExpressions;

namespace _378daftarkhoneh.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Blog
        public async Task<IActionResult> Index(string searchString, string category, bool? isPublished, int page = 1)
        {
            var query = _context.BlogPosts.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.Title.Contains(searchString) || 
                                        p.Summary.Contains(searchString) ||
                                        p.Content.Contains(searchString));
                ViewBag.SearchString = searchString;
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
                ViewBag.Category = category;
            }

            if (isPublished.HasValue)
            {
                query = query.Where(p => p.IsPublished == isPublished.Value);
                ViewBag.IsPublished = isPublished;
            }

            // Pagination
            int pageSize = 10;
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var posts = await query
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = page > 1;
            ViewBag.HasNextPage = page < totalPages;

            // Get categories for filter
            ViewBag.Categories = await _context.BlogPosts
                .Where(p => !string.IsNullOrEmpty(p.Category))
                .Select(p => p.Category)
                .Distinct()
                .ToListAsync();

            return View(posts);
        }

        // GET: Admin/Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // GET: Admin/Blog/Create
        public IActionResult Create()
        {
            var post = new BlogPost 
            { 
                Title = "",
                Summary = "",
                Content = "",
                CreatedAt = DateTime.Now 
            };
            return View(post);
        }

        // POST: Admin/Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Summary,Content,Author,ImageUrl,Category,Tags,IsPublished,IsFeatured,MetaDescription,MetaKeywords")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                // Generate slug from title
                blogPost.Slug = GenerateSlug(blogPost.Title);
                
                // Ensure unique slug
                await EnsureUniqueSlug(blogPost);

                blogPost.CreatedAt = DateTime.Now;
                
                if (blogPost.IsPublished)
                {
                    blogPost.PublishedAt = DateTime.Now;
                }

                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                TempData["Success"] = "پست با موفقیت ایجاد شد";
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: Admin/Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        // POST: Admin/Blog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Summary,Content,Author,ImageUrl,Category,Tags,IsPublished,IsFeatured,MetaDescription,MetaKeywords,Slug,CreatedAt,PublishedAt,ViewCount")] BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update slug if title changed
                    var currentPost = await _context.BlogPosts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    if (currentPost != null && currentPost.Title != blogPost.Title)
                    {
                        blogPost.Slug = GenerateSlug(blogPost.Title);
                        await EnsureUniqueSlug(blogPost);
                    }

                    blogPost.UpdatedAt = DateTime.Now;
                    
                    // Set published date if publishing for first time
                    if (blogPost.IsPublished && currentPost?.IsPublished != true)
                    {
                        blogPost.PublishedAt = DateTime.Now;
                    }

                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "پست با موفقیت ویرایش شد";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: Admin/Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost);
                await _context.SaveChangesAsync();
                TempData["Success"] = "پست با موفقیت حذف شد";
            }
            return RedirectToAction(nameof(Index));
        }

        // Toggle Published Status
        [HttpPost]
        public async Task<IActionResult> TogglePublished(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            post.IsPublished = !post.IsPublished;
            post.UpdatedAt = DateTime.Now;
            
            if (post.IsPublished)
            {
                post.PublishedAt = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            
            var status = post.IsPublished ? "منتشر" : "پیش‌نویس";
            TempData["Success"] = $"وضعیت پست به {status} تغییر یافت";
            
            return RedirectToAction(nameof(Index));
        }

        // Toggle Featured Status
        [HttpPost]
        public async Task<IActionResult> ToggleFeatured(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            post.IsFeatured = !post.IsFeatured;
            post.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            
            var status = post.IsFeatured ? "ویژه" : "عادی";
            TempData["Success"] = $"وضعیت پست به {status} تغییر یافت";
            
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.Id == id);
        }

        private string GenerateSlug(string title)
        {
            if (string.IsNullOrEmpty(title))
                return "";

            // Convert to lowercase
            string slug = title.ToLowerInvariant();

            // Replace Persian/Arabic characters with English
            var persianToEnglish = new Dictionary<char, string>
            {
                ['آ'] = "a", ['ا'] = "a", ['ب'] = "b", ['پ'] = "p", ['ت'] = "t", ['ث'] = "s",
                ['ج'] = "j", ['چ'] = "ch", ['ح'] = "h", ['خ'] = "kh", ['د'] = "d", ['ذ'] = "z",
                ['ر'] = "r", ['ز'] = "z", ['ژ'] = "zh", ['س'] = "s", ['ش'] = "sh", ['ص'] = "s",
                ['ض'] = "z", ['ط'] = "t", ['ظ'] = "z", ['ع'] = "a", ['غ'] = "gh", ['ف'] = "f",
                ['ق'] = "gh", ['ک'] = "k", ['گ'] = "g", ['ل'] = "l", ['م'] = "m", ['ن'] = "n",
                ['و'] = "v", ['ه'] = "h", ['ی'] = "y"
            };

            foreach (var kvp in persianToEnglish)
            {
                slug = slug.Replace(kvp.Key.ToString(), kvp.Value);
            }

            // Remove special characters and replace spaces with hyphens
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"\s+", "-").Trim();
            slug = Regex.Replace(slug, @"-+", "-");

            return slug;
        }

        private async Task EnsureUniqueSlug(BlogPost post)
        {
            string baseSlug = post.Slug ?? "";
            string uniqueSlug = baseSlug;
            int counter = 1;

            while (await _context.BlogPosts.AnyAsync(p => p.Slug == uniqueSlug && p.Id != post.Id))
            {
                uniqueSlug = $"{baseSlug}-{counter}";
                counter++;
            }

            post.Slug = uniqueSlug;
        }
    }
} 