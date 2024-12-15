using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Women_Empowerment.Models
{
    public class STEP
    {
       [Key]
        public int TraineeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string ContactNumber { get; set; }

        public string FamilyMembersName { get; set; }
        public string Relation { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        public string Course { get; set; }

        [Required(ErrorMessage = "Course duration is required")]
        public string CourseDuration { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public string RegistrationId { get; set; }
        public string Status { get; set; }

    }
}
