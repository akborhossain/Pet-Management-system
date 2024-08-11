using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Management_System.Models.Entities
{
    public class Pet
    {
        public int PetId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Pet Name")]
        public string PetName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Pet Type")]
        public string PetType { get; set; }
        [Required]
        [DisplayName("Pet Age")]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Pet Color")]
        public string Color { get; set; }
        [Required]
        [StringLength(50)]
        public string Gender { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Owner Name")]
        public string OwnerName { get; set; }
        [Required]
        [StringLength(500)]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

    }
}
