using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GF5BAB_SOF_2023241_Webapp.Models
{
    public class Part
    {
        [Key]
        public string Uid { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Part's name can be maximum 30 caratcters.")]
        public string Name { get; set; }

        [Required]
        [Range(0, 99999, ErrorMessage = "Part's width must be between 0 and 99999.")]
        public double Width { get; set; }

        [Required]
        [Range(0, 99999,ErrorMessage = "Part's height must be between 0 and 99999.")]
        public double Heigth { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Part's serial number can be maximum 15 caratcters.")]
        public string SerialNumber { get; set; }

        public string EngineerId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual SiteUser Engineer { get; set; }
        public Part()
        {
            Uid = Guid.NewGuid().ToString();
        }
    }
}
