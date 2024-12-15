using System.ComponentModel.DataAnnotations;

namespace Women_Empowerment.Models
{
    public class NGO
    {
        [Key]
        public int NGOId { get; set; }

        [Required(ErrorMessage = "NGO Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        public string TrainingSectors { get; set; }

        [Required(ErrorMessage = "Contact Details are required.")]
        public string ContactDetails { get; set; }

        public string RegistrationId { get; set; } // Removed [Required] attribute

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }
    }
}
