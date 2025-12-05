using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Models.DTO
{
    public class DersDto
    {
        public int DersId { get; set; }

        public string DersAdi { get; set; }

        public int? DersSuresi { get; set; }
    }
}
