using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using _378daftarkhoneh.Models;
using _378daftarkhoneh.Data;

namespace _378daftarkhoneh.Controllers
{
    public class UserPanelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public UserPanelController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: UserPanel/Register
        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Dashboard");
            
            return View();
        }

        // POST: UserPanel/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if username or email already exists
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.Username || u.Email == model.Email);
                
                if (existingUser != null)
                {
                    if (existingUser.Username == model.Username)
                        ModelState.AddModelError("Username", "این نام کاربری قبلاً استفاده شده است");
                    if (existingUser.Email == model.Email)
                        ModelState.AddModelError("Email", "این ایمیل قبلاً ثبت شده است");
                    
                    return View(model);
                }

                var user = new User
                {
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    NationalCode = model.NationalCode,
                    Address = model.Address,
                    Password = model.Password, // In real app, hash this password
                    Role = UserRole.User,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                TempData["Success"] = "ثبت نام با موفقیت انجام شد. اکنون می‌توانید وارد شوید.";
                return RedirectToAction("Login");
            }

            return View(model);
        }

        // GET: UserPanel/Login
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Dashboard");
            
            return View();
        }

        // POST: UserPanel/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password && u.IsActive);

                if (user != null)
                {
                    // Update last login
                    user.LastLoginAt = DateTime.Now;
                    await _context.SaveChangesAsync();

                    // Sign in
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.GivenName, user.FullName),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe,
                        ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddDays(30) : DateTimeOffset.UtcNow.AddHours(24)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Dashboard");
                }

                ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه است");
            }

            return View(model);
        }

        // GET: UserPanel/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userFiles = await _context.UserFiles
                .Include(f => f.Category)
                .Where(f => f.UserId == userId)
                .OrderByDescending(f => f.UploadedAt)
                .Take(10)
                .ToListAsync();

            ViewBag.TotalFiles = await _context.UserFiles.CountAsync(f => f.UserId == userId);
            ViewBag.PendingFiles = await _context.UserFiles.CountAsync(f => f.UserId == userId && f.Status == FileStatus.Pending);
            ViewBag.CompletedFiles = await _context.UserFiles.CountAsync(f => f.UserId == userId && f.Status == FileStatus.Completed);

            return View(userFiles);
        }

        // GET: UserPanel/UploadFile
        public async Task<IActionResult> UploadFile()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }

        // POST: UserPanel/UploadFile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadFile(IFormFile file, string title, string description, int categoryId, RequestType requestType)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("file", "لطفاً فایل را انتخاب کنید");
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View();
            }

            if (string.IsNullOrEmpty(title))
            {
                ModelState.AddModelError("title", "عنوان فایل الزامی است");
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View();
            }

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Create upload directory if not exists
            var uploadsPath = Path.Combine(_environment.WebRootPath, "uploads", "users");
            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            // Generate unique filename
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(uploadsPath, fileName);

            // Save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Save to database
            var category = await _context.Categories.FindAsync(categoryId);
            var user = await _context.Users.FindAsync(userId);
            
            if (category == null || user == null)
            {
                ModelState.AddModelError("", "دسته‌بندی یا کاربر نامعتبر است");
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View();
            }

            var userFile = new UserFile
            {
                Title = title,
                Description = description,
                FilePath = $"/uploads/users/{fileName}",
                OriginalFileName = file.FileName,
                FileType = file.ContentType,
                FileSize = file.Length,
                UserId = userId,
                CategoryId = categoryId,
                RequestType = requestType,
                Status = FileStatus.Pending,
                UploadedAt = DateTime.Now,
                User = user,
                Category = category
            };

            _context.UserFiles.Add(userFile);
            await _context.SaveChangesAsync();

            TempData["Success"] = "فایل با موفقیت آپلود شد و در صف بررسی قرار گرفت";
            return RedirectToAction("Dashboard");
        }

        // GET: UserPanel/MyFiles
        public async Task<IActionResult> MyFiles()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userFiles = await _context.UserFiles
                .Include(f => f.Category)
                .Include(f => f.ProcessedByUser)
                .Where(f => f.UserId == userId)
                .OrderByDescending(f => f.UploadedAt)
                .ToListAsync();

            return View(userFiles);
        }

        // GET: UserPanel/Profile
        public async Task<IActionResult> Profile()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
                return NotFound();

            // Add file statistics to ViewBag
            ViewBag.TotalFiles = await _context.UserFiles.CountAsync(f => f.UserId == userId);
            ViewBag.PendingFiles = await _context.UserFiles.CountAsync(f => f.UserId == userId && f.Status == FileStatus.Pending);
            ViewBag.CompletedFiles = await _context.UserFiles.CountAsync(f => f.UserId == userId && f.Status == FileStatus.Completed);

            return View(user);
        }

        // POST: UserPanel/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
} 