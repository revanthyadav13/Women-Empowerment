using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Women_Empowerment.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "username is required.")]
        [StringLength(50, ErrorMessage = "username cannot be longer than 50 characters.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "DOB is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Please enter a valid contact number.")]
        [Display(Name = "Contact Number")]
        public string? ContactNumber { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        public bool isActive { get; set; }

       public string Role { get; set; }
    }
}
