using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GF5BAB_SOF_2023241_Webapp.Models
{
    public class Test
    {
        [Key]
        public string Uid { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Test's name can be maximum 30 caratcters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Part's name can be maximum 30 caratcters.")]
        public string PartName { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "Starting time title can be maximum 9 caracters.")]
        public string StartingTime { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "Ending time title can be maximum 9 caracters.")]
        public string EndingTime { get; set; }
        public string DriverId { get; set; }

        [NotMapped]
        public virtual SiteUser Driver { get; set; }
        public Test()
        {
            Uid = Guid.NewGuid().ToString();
        }
    }
}
