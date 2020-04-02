using System.ComponentModel.DataAnnotations;

namespace UserSignUp.Domain
{
    public class User: UserInfo
    {
        public int Id { get; set; }
        public string ActivationCode { get; set; }
        public bool ActivationMailSent { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Email Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }
    }
}