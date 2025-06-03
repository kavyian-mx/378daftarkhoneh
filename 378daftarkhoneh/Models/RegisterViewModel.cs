using System.ComponentModel.DataAnnotations;

namespace _378daftarkhoneh.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        [StringLength(50, ErrorMessage = "نام کاربری باید بین ۳ تا ۵۰ کاراکتر باشد", MinimumLength = 3)]
        public required string Username { get; set; }
        
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
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی باید ۱۰ رقم باشد")]
        public string? NationalCode { get; set; }
        
        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "رمز عبور باید حداقل ۶ کاراکتر باشد", MinimumLength = 6)]
        public required string Password { get; set; }
        
        [Required(ErrorMessage = "تکرار رمز عبور الزامی است")]
        [Display(Name = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن باید یکسان باشد")]
        public required string ConfirmPassword { get; set; }
        
        [Display(Name = "آدرس")]
        [StringLength(500)]
        public string? Address { get; set; }
        
        [Required(ErrorMessage = "پذیرش قوانین الزامی است")]
        [Display(Name = "قوانین و مقررات را می‌پذیرم")]
        public bool AcceptTerms { get; set; }
    }
} 