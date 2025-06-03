using System.ComponentModel.DataAnnotations;

namespace _378daftarkhoneh.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان الزامی است")]
        [StringLength(200, ErrorMessage = "عنوان نمی‌تواند بیش از 200 کاراکتر باشد")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "خلاصه مطلب الزامی است")]
        [StringLength(500, ErrorMessage = "خلاصه نمی‌تواند بیش از 500 کاراکتر باشد")]
        public required string Summary { get; set; }

        [Required(ErrorMessage = "متن مطلب الزامی است")]
        public required string Content { get; set; }

        [StringLength(200, ErrorMessage = "نام نویسنده نمی‌تواند بیش از 200 کاراکتر باشد")]
        public string? Author { get; set; } = "دفترخانه ۳۷۸";

        public string? ImageUrl { get; set; }

        [StringLength(100, ErrorMessage = "دسته‌بندی نمی‌تواند بیش از 100 کاراکتر باشد")]
        public string? Category { get; set; }

        [StringLength(500, ErrorMessage = "تگ‌ها نمی‌تواند بیش از 500 کاراکتر باشد")]
        public string? Tags { get; set; }

        public bool IsPublished { get; set; } = true;

        public bool IsFeatured { get; set; } = false;

        public int ViewCount { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? PublishedAt { get; set; }

        // SEO Properties
        [StringLength(160, ErrorMessage = "متا توضیحات نمی‌تواند بیش از 160 کاراکتر باشد")]
        public string? MetaDescription { get; set; }

        [StringLength(100, ErrorMessage = "متا کلیدواژه‌ها نمی‌تواند بیش از 100 کاراکتر باشد")]
        public string? MetaKeywords { get; set; }

        // URL Slug for SEO-friendly URLs
        [StringLength(200, ErrorMessage = "اسلاگ نمی‌تواند بیش از 200 کاراکتر باشد")]
        public string? Slug { get; set; }
    }
} 