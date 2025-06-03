using System.ComponentModel.DataAnnotations;

namespace _378daftarkhoneh.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        [StringLength(50, ErrorMessage = "نام کاربری باید بین ۳ تا ۵۰ کاراکتر باشد", MinimumLength = 3)]
        public required string Username { get; set; }
        
        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "رمز عبور باید حداقل ۶ کاراکتر باشد", MinimumLength = 6)]
        public required string Password { get; set; }
        
        [Required(ErrorMessage = "نام الزامی است")]
        [Display(Name = "نام")]
        [StringLength(50)]
        public required string FirstName { get; set; }
        
        [Required(ErrorMessage = "نام خانوادگی الزامی است")]
        [Display(Name = "نام خانوادگی")]
        [StringLength(50)]
        public required string LastName { get; set; }
        
        [Required(ErrorMessage = "ایمیل الزامی است")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل نامعتبر است")]
        public required string Email { get; set; }
        
        [Display(Name = "شماره تلفن")]
        [Phone(ErrorMessage = "شماره تلفن نامعتبر است")]
        public string? Phone { get; set; }
        
        [Display(Name = "کد ملی")]
        [StringLength(10, ErrorMessage = "کد ملی باید ۱۰ رقم باشد", MinimumLength = 10)]
        public string? NationalCode { get; set; }
        
        [Display(Name = "آدرس")]
        [StringLength(500)]
        public string? Address { get; set; }
        
        [Display(Name = "وضعیت فعالیت")]
        public bool IsActive { get; set; } = true;
        
        [Display(Name = "نقش کاربر")]
        public UserRole Role { get; set; } = UserRole.User;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLoginAt { get; set; }
        
        // Navigation property
        public virtual ICollection<UserFile> UserFiles { get; set; } = new List<UserFile>();
        
        [Display(Name = "نام کامل")]
        public string FullName => $"{FirstName} {LastName}";
    }
    
    public enum UserRole
    {
        [Display(Name = "کاربر عادی")]
        User = 0,
        [Display(Name = "مدیر")]
        Admin = 1,
        [Display(Name = "ادمین ارشد")]
        SuperAdmin = 2
    }
} 