using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Models
{
    public class Ogretmen
    {
        public string Sube;

        [Key]
        [Column(name: "ogretmen_id")]
        public int OgretmenId { get; set; }

        [Column(name: "ogretmen_adi")]
        public string OgretmenAdi { get; set; }

        [Column(name: "ogretmen_soyadi")]
        public string OgretmenSoyadi { get; set; }

        [Column(name: "brans")]
        public string Brans { get; set; }

        [Column(name: "sinif")]
        public int? Sinif { get; set; }
    }
}
