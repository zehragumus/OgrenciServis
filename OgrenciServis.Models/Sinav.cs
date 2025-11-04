using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Models
{
    public class Sinav
    {
        [Key]
        [Column(name:"sinav_id")]
        public int SinavId { get; set; }

        [Column(name: "ders_id")]

        public int? DersId { get; set; }

        [Column(name: "ogrenci_id")]
        public int? OgrencId { get; set; }

        [Column(name: "ogretmen_id")]
        public int? OgretmenId { get; set; }

        [Column(name: "not")]
        public int? Not { get; set; }
    }
}
