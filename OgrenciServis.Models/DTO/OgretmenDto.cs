using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Models.DTO
{
    public class OgretmenDto
    {
        public int OgretmenId { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string Sube { get; set; }

        public int? SinifNo { get; set; }

        public string Brans { get; set; }
    }
}
