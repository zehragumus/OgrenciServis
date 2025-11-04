using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Models.DTO
{
    public class OgrenciDto
    {
        public int OgrenciId { get; set; }

        public string Adi { get; set; } 

        public string Soyadi { get; set; }

        public DateTime? DogumTarihi { get; set; }

        public string Sube { get; set; }

        public int? SinifNo { get; set; }
    }
}
