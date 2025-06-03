using System.ComponentModel.DataAnnotations;

namespace _378daftarkhoneh.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "نام کاربری")]
        public required string Username { get; set; }
        
        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
} 