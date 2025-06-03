using System.ComponentModel.DataAnnotations;

namespace _378daftarkhoneh.Models
{
    public class UserFile
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "عنوان فایل")]
        [StringLength(200)]
        public required string Title { get; set; }
        
        [Display(Name = "توضیحات")]
        [StringLength(500)]
        public string? Description { get; set; }
        
        [Required]
        [Display(Name = "مسیر فایل")]
        public required string FilePath { get; set; }
        
        [Display(Name = "نام فایل اصلی")]
        public required string OriginalFileName { get; set; }
        
        [Display(Name = "نوع فایل")]
        public required string FileType { get; set; }
        
        [Display(Name = "حجم فایل")]
        public long FileSize { get; set; }
        
        [Display(Name = "وضعیت فایل")]
        public FileStatus Status { get; set; } = FileStatus.Pending;
        
        [Display(Name = "نوع درخواست")]
        public RequestType RequestType { get; set; }
        
        [Display(Name = "یادداشت مدیر")]
        [StringLength(1000)]
        public string? AdminNote { get; set; }
        
        public DateTime UploadedAt { get; set; } = DateTime.Now;
        public DateTime? ProcessedAt { get; set; }
        
        // Foreign Keys
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? ProcessedByUserId { get; set; }
        
        // Navigation Properties
        public virtual required User User { get; set; }
        public virtual required Category Category { get; set; }
        public virtual User? ProcessedByUser { get; set; }
    }
    
    public enum FileStatus
    {
        [Display(Name = "در انتظار بررسی")]
        Pending = 0,
        [Display(Name = "در حال بررسی")]
        InProgress = 1,
        [Display(Name = "تکمیل شده")]
        Completed = 2,
        [Display(Name = "رد شده")]
        Rejected = 3,
        [Display(Name = "نیاز به اطلاعات بیشتر")]
        NeedMoreInfo = 4
    }
    
    public enum RequestType
    {
        [Display(Name = "تنظیم سند")]
        DocumentPreparation = 0,
        [Display(Name = "مشاوره")]
        Consultation = 1,
        [Display(Name = "استعلام")]
        Inquiry = 2,
        [Display(Name = "گواهی")]
        Certificate = 3,
        [Display(Name = "سایر")]
        Other = 4
    }
} 