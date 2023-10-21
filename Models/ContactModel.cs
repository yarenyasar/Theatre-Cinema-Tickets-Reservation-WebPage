using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models {
    public class ContactModel {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name-Surname")]
        public string NameSurname { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "E-Mail")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(1024)]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
