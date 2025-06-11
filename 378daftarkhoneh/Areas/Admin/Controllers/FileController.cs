using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using _378daftarkhoneh.Models;
using _378daftarkhoneh.Data;

namespace _378daftarkhoneh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var files = await _context.FileUploads
                .Include(f => f.Category)
                .OrderByDescending(f => f.UploadedAt)
                .ToListAsync();
            return View(files);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FileUpload fileUpload, IFormFile uploadedFile)
        {
            if (!ModelState.IsValid || uploadedFile == null)
            {
                ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", fileUpload.CategoryId);
                ModelState.AddModelError("uploadedFile", "فایل الزامی است.");
                return View(fileUpload);
            }

            if (uploadedFile.ContentType != "application/pdf")
            {
                ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", fileUpload.CategoryId);
                ModelState.AddModelError("uploadedFile", "فقط فایل‌های PDF مجاز هستند.");
                return View(fileUpload);
            }

            // Save dummy to get ID
            fileUpload.FileName = "temp";
            fileUpload.FilePath = "temp";
            fileUpload.FileSize = 0;
            fileUpload.FileType = "temp";

            _context.Add(fileUpload);
            await _context.SaveChangesAsync();

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string extension = Path.GetExtension(uploadedFile.FileName);
            string uniqueFileName = $"file_{fileUpload.Id}{extension}";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            fileUpload.FileName = uploadedFile.FileName;
            fileUpload.FilePath = "/uploads/" + uniqueFileName;
            fileUpload.FileSize = uploadedFile.Length;
            fileUpload.FileType = uploadedFile.ContentType;

            _context.Update(fileUpload);
            await _context.SaveChangesAsync();

            TempData["Success"] = "فایل با موفقیت آپلود شد";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var fileUpload = await _context.FileUploads.FindAsync(id);
            if (fileUpload == null) return NotFound();

            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", fileUpload.CategoryId);
            return View(fileUpload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FileUpload fileUpload, IFormFile uploadedFile)
        {
            if (id != fileUpload.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", fileUpload.CategoryId);
                return View(fileUpload);
            }

            var existingFile = await _context.FileUploads.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
            if (existingFile == null) return NotFound();

            if (uploadedFile != null)
            {
                if (uploadedFile.ContentType != "application/pdf")
                {
                    ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", fileUpload.CategoryId);
                    ModelState.AddModelError("uploadedFile", "فقط فایل‌های PDF مجاز هستند.");
                    return View(fileUpload);
                }

                // Remove old file
                if (!string.IsNullOrEmpty(existingFile.FilePath))
                {
                    string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, existingFile.FilePath.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                // Save new file
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string extension = Path.GetExtension(uploadedFile.FileName);
                string uniqueFileName = $"file_{fileUpload.Id}{extension}";
                string newFilePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(newFilePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                fileUpload.FileName = uploadedFile.FileName;
                fileUpload.FilePath = "/uploads/" + uniqueFileName;
                fileUpload.FileSize = uploadedFile.Length;
                fileUpload.FileType = uploadedFile.ContentType;
            }
            else
            {
                fileUpload.FileName = existingFile.FileName;
                fileUpload.FilePath = existingFile.FilePath;
                fileUpload.FileSize = existingFile.FileSize;
                fileUpload.FileType = existingFile.FileType;
            }

            _context.Update(fileUpload);
            await _context.SaveChangesAsync();
            TempData["Success"] = "فایل با موفقیت ویرایش شد";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var fileUpload = await _context.FileUploads.FindAsync(id);
            if (fileUpload != null)
            {
                if (!string.IsNullOrEmpty(fileUpload.FilePath))
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, fileUpload.FilePath.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.FileUploads.Remove(fileUpload);
                await _context.SaveChangesAsync();
                TempData["Success"] = "فایل با موفقیت حذف شد";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FileUploadExists(int id)
        {
            return _context.FileUploads.Any(e => e.Id == id);
        }
    }
}