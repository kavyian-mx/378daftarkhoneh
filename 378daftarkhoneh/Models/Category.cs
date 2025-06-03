using System.ComponentModel.DataAnnotations;

namespace _378daftarkhoneh.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "نام دسته‌بندی الزامی است")]
        [Display(Name = "نام دسته‌بندی")]
        public required string Name { get; set; }
        
        [Display(Name = "توضیحات")]
        public string Description { get; set; } = string.Empty;
        
        [Display(Name = "رنگ")]
        public string Color { get; set; } = "#3498db";
        
        [Display(Name = "آیکون")]
        public string Icon { get; set; } = "fa-folder";
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // Navigation property
        public virtual ICollection<FileUpload> Files { get; set; } = new List<FileUpload>();
    }
} 