using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _378daftarkhoneh.Models
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان فایل الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        // این‌ها در کنترلر مقدار می‌گیرند، پس [Required] نباید داشته باشند
        [Display(Name = "نام فایل")]
        public string FileName { get; set; } = string.Empty;

        [Display(Name = "مسیر فایل")]
        public string FilePath { get; set; } = string.Empty;

        [Display(Name = "حجم فایل")]
        public long FileSize { get; set; }

        [Display(Name = "نوع فایل")]
        public string FileType { get; set; } = string.Empty;

        [Required(ErrorMessage = "دسته‌بندی الزامی است")]
        [Display(Name = "دسته‌بندی")]
        public int CategoryId { get; set; }

        [Display(Name = "تاریخ بارگذاری")]
        public DateTime UploadedAt { get; set; } = DateTime.Now;

        // Navigation property
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
    }
}
