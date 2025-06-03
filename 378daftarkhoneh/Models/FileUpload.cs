using System.ComponentModel.DataAnnotations;

namespace _378daftarkhoneh.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "عنوان")]
        public required string Title { get; set; }
        
        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
        
        [Required]
        [Display(Name = "نام فایل")]
        public required string FileName { get; set; }
        
        [Display(Name = "مسیر فایل")]
        public required string FilePath { get; set; }
        
        [Display(Name = "حجم فایل")]
        public long FileSize { get; set; }
        
        [Display(Name = "نوع فایل")]
        public required string FileType { get; set; }
        
        [Required(ErrorMessage = "دسته‌بندی الزامی است")]
        [Display(Name = "دسته‌بندی")]
        public int CategoryId { get; set; }
        
        public DateTime UploadedAt { get; set; } = DateTime.Now;
        
        // Navigation property
        public virtual required Category Category { get; set; }
    }
} 