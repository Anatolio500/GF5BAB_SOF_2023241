using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GF5BAB_SOF_2023241_Webapp.Models
{
    public class Meeting
    {
        [Key]
        public string Uid { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "The Name can be maximum 15 characters long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The Topics can be maximum 30 caracters long.")]
        public string Topics { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 3, ErrorMessage = "Wrong format for starting time.")]
        public string StartingTime { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 3, ErrorMessage = "Wrong format for ending time.")]
        public string EndingTime { get; set; }

        public string TeamPrincipalId { get; set; }

        [NotMapped]
        public virtual SiteUser TeamPrincipal { get; set; }
        public Meeting()
        {
            Uid = Guid.NewGuid().ToString();
        }
    }
}
