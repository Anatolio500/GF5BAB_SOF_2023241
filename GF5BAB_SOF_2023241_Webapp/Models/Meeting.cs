using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GF5BAB_SOF_2023241_Webapp.Models
{
    public class Meeting
    {
        [Key]
        public string Uid { get; set; }

        public string Name { get; set; }

        public string Topics { get; set; }
        public string StartingTime { get; set; }
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
