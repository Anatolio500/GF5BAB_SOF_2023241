using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GF5BAB_SOF_2023241_Webapp.Models
{
    public class Test
    {
        [Key]
        public string Uid { get; set; }

        public string Name { get; set; }

        public string PartName { get; set; }

        public string StartingTime { get; set; }
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
