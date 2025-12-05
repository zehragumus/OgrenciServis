using OgrenciServis.Models;
using OgrenciServis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Interface
{
    public interface ISinav
    {
        IEnumerable<SinavDto> TumSinavlariListele();

        SinavDto? SinavGetirById(int id);

        Sinav SinavEkle  (Sinav sinav);

        Sinav? SinavGuncelle(int id, Sinav sinav);

        bool SinavSil(int id);
   
       
    }
}
