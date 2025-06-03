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
            if (ModelState.IsValid && uploadedFile != null)
            {
                // Create uploads directory if not exists
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate unique filename
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + uploadedFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save file to disk
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                // Update file information
                fileUpload.FileName = uploadedFile.FileName;
                fileUpload.FilePath = "/uploads/" + uniqueFileName;
                fileUpload.FileSize = uploadedFile.Length;
                fileUpload.FileType = uploadedFile.ContentType;

                _context.Add(fileUpload);
                await _context.SaveChangesAsync();
                TempData["Success"] = "فایل با موفقیت آپلود شد";
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", fileUpload.CategoryId);
            return View(fileUpload);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileUpload = await _context.FileUploads.FindAsync(id);
            if (fileUpload == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", fileUpload.CategoryId);
            return View(fileUpload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FileUpload fileUpload, IFormFile uploadedFile)
        {
            if (id != fileUpload.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingFile = await _context.FileUploads.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);

                    if (uploadedFile != null)
                    {
                        // Delete old file
                        if (!string.IsNullOrEmpty(existingFile.FilePath))
                        {
                            string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, existingFile.FilePath.TrimStart('/'));
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }

                        // Upload new file
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + uploadedFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
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
                        // Keep existing file information
                        fileUpload.FileName = existingFile.FileName;
                        fileUpload.FilePath = existingFile.FilePath;
                        fileUpload.FileSize = existingFile.FileSize;
                        fileUpload.FileType = existingFile.FileType;
                    }

                    _context.Update(fileUpload);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "فایل با موفقیت ویرایش شد";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileUploadExists(fileUpload.Id))
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

            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", fileUpload.CategoryId);
            return View(fileUpload);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var fileUpload = await _context.FileUploads.FindAsync(id);
            if (fileUpload != null)
            {
                // Delete physical file
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