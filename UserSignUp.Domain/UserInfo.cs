using System.ComponentModel.DataAnnotations;

namespace UserSignUp.Domain
{
    public class UserInfo
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address Line1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Line1 is required")]
        [DataType(DataType.Text)]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line2")]
        [DataType(DataType.Text)]
        public string AddressLine2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "State is required")]
        [DataType(DataType.Text)]
        [MaxLength(2, ErrorMessage = "Max 2 characters can be specified")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ZipCode is required")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        
        [Display(Name = "Notifications?")]
        public bool AllowNotifications { get; set; }
        [Display(Name = "Promotion Emails?")]
        public bool AllowPromoEmails { get; set; }
    }
}
