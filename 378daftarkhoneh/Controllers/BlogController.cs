using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _378daftarkhoneh.Data;
using _378daftarkhoneh.Models;

namespace _378daftarkhoneh.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Blog
        public async Task<IActionResult> Index(string searchString, string category, int page = 1)
        {
            var query = _context.BlogPosts
                .Where(p => p.IsPublished)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.Title.Contains(searchString) || 
                                        p.Summary.Contains(searchString) ||
                                        p.Content.Contains(searchString) ||
                                        (p.Tags != null && p.Tags.Contains(searchString)));
                ViewBag.SearchString = searchString;
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
                ViewBag.Category = category;
            }

            // Pagination
            int pageSize = 6;
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var posts = await query
                .OrderByDescending(p => p.PublishedAt ?? p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = page > 1;
            ViewBag.HasNextPage = page < totalPages;

            // Get categories for filter
            ViewBag.Categories = await _context.BlogPosts
                .Where(p => p.IsPublished && !string.IsNullOrEmpty(p.Category))
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToListAsync();

            // Get featured posts
            ViewBag.FeaturedPosts = await _context.BlogPosts
                .Where(p => p.IsPublished && p.IsFeatured)
                .OrderByDescending(p => p.PublishedAt ?? p.CreatedAt)
                .Take(3)
                .ToListAsync();

            // Get recent posts for sidebar
            ViewBag.RecentPosts = await _context.BlogPosts
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.PublishedAt ?? p.CreatedAt)
                .Take(5)
                .ToListAsync();

            return View(posts);
        }

        // GET: Blog/Details/slug or Blog/Details/id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            BlogPost? blogPost = null;

            // Try to find by slug first
            blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(p => p.Slug == id && p.IsPublished);

            // If not found by slug, try by ID
            if (blogPost == null && int.TryParse(id, out int postId))
            {
                blogPost = await _context.BlogPosts
                    .FirstOrDefaultAsync(p => p.Id == postId && p.IsPublished);
            }

            if (blogPost == null)
            {
                return NotFound();
            }

            // Increment view count
            blogPost.ViewCount++;
            await _context.SaveChangesAsync();

            // Get related posts
            ViewBag.RelatedPosts = await _context.BlogPosts
                .Where(p => p.IsPublished && 
                           p.Id != blogPost.Id && 
                           (!string.IsNullOrEmpty(p.Category) && p.Category == blogPost.Category))
                .OrderByDescending(p => p.PublishedAt ?? p.CreatedAt)
                .Take(3)
                .ToListAsync();

            // Get recent posts for sidebar
            ViewBag.RecentPosts = await _context.BlogPosts
                .Where(p => p.IsPublished && p.Id != blogPost.Id)
                .OrderByDescending(p => p.PublishedAt ?? p.CreatedAt)
                .Take(5)
                .ToListAsync();

            // Get categories for sidebar
            ViewBag.Categories = await _context.BlogPosts
                .Where(p => p.IsPublished && !string.IsNullOrEmpty(p.Category))
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToListAsync();

            return View(blogPost);
        }

        // GET: Blog/Category/categoryName
        public async Task<IActionResult> Category(string id, int page = 1)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var query = _context.BlogPosts
                .Where(p => p.IsPublished && p.Category == id);

            // Pagination
            int pageSize = 6;
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var posts = await query
                .OrderByDescending(p => p.PublishedAt ?? p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = page > 1;
            ViewBag.HasNextPage = page < totalPages;
            ViewBag.CategoryName = id;

            // Get categories for sidebar
            ViewBag.Categories = await _context.BlogPosts
                .Where(p => p.IsPublished && !string.IsNullOrEmpty(p.Category))
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToListAsync();

            // Get recent posts for sidebar
            ViewBag.RecentPosts = await _context.BlogPosts
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.PublishedAt ?? p.CreatedAt)
                .Take(5)
                .ToListAsync();

            return View("Index", posts);
        }

        // GET: Blog/Search
        public async Task<IActionResult> Search(string q, int page = 1)
        {
            if (string.IsNullOrEmpty(q))
            {
                return RedirectToAction(nameof(Index));
            }

            var query = _context.BlogPosts
                .Where(p => p.IsPublished && 
                           (p.Title.Contains(q) || 
                            p.Summary.Contains(q) || 
                            p.Content.Contains(q) ||
                            (p.Tags != null && p.Tags.Contains(q))));

            // Pagination
            int pageSize = 6;
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var posts = await query
                .OrderByDescending(p => p.PublishedAt ?? p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.HasPreviousPage = page > 1;
            ViewBag.HasNextPage = page < totalPages;
            ViewBag.SearchQuery = q;
            ViewBag.SearchResults = totalCount;

            // Get categories for sidebar
            ViewBag.Categories = await _context.BlogPosts
                .Where(p => p.IsPublished && !string.IsNullOrEmpty(p.Category))
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToListAsync();

            // Get recent posts for sidebar
            ViewBag.RecentPosts = await _context.BlogPosts
                .Where(p => p.IsPublished)
                .OrderByDescending(p => p.PublishedAt ?? p.CreatedAt)
                .Take(5)
                .ToListAsync();

            return View("Index", posts);
        }
    }
} 