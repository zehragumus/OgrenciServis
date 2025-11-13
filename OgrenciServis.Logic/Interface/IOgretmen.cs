using OgrenciServis.Models;
using OgrenciServis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Interface
{
    public interface IOgretmen
    {
        IEnumerable<OgretmenDto> TumOgretmenleriListele();
        OgretmenDto? OgretmenGetirById(int id);

        Ogretmen OgretmenEkle(Ogretmen ogretmen);

        Ogretmen? OgretmenGuncelle(int id, Ogretmen ogretmen);

        bool OgretmenSil(int id);
    }

}
