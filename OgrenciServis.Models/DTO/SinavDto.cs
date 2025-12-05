using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace OgrenciServis.Models.DTO
 {
        public class SinavDto
        {
            public int SinavId { get; set; }

            public int? Not { get; set; }


            public string DersAdi { get; set; }

            public int? DersSuresi { get; set; }



            public string OgrenciAdi { get; set; }

            public string OgrenciSoyadi { get; set; }


            public string OgretmenAdi { get; set; }

            public string OgretmenSoyadi { get; set; }

            public string Brans { get; set; }

        }

 }
 


