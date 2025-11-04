using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Models
{
    public class Ders
    {
        [Key]
        [Column(name: "ders_id")]
        public int DersId { get; set; }

        [Column(name: "ders_adi")]
        public string DersAdi { get; set; }

        [Column(name: "ders_suresi")]
        public int? DersSuresi { get; set; }
    }
}
