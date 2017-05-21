using System.ComponentModel.DataAnnotations;

namespace AspMVC5Training.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "全名")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "地址")]
        public string AddressLine { get; set; }

        [Required]
        [Display(Name = "國籍")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "年齡")]
        [Range(1,200)]
        public int Age { get; set; }

        
    }
}