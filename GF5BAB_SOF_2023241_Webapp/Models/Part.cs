using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GF5BAB_SOF_2023241_Webapp.Models
{
    public class Part
    {
        [Key]
        public string Uid { get; set; }

        public string Name { get; set; }

        public double Width { get; set; }
        public double Heigth { get; set; }

        public string SerialNumber { get; set; }

        public string EngineerId { get; set; }

       
        public Part()
        {
            Uid = Guid.NewGuid().ToString();
        }
    }
}
