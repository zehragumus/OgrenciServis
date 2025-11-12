using OgrenciServis.Models;
using OgrenciServis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Interface
{
    public interface IOgrenci
    {
        IEnumerable<OgrenciDto> TumOgrencileriListele();

        OgrenciDto? OgrenciGetirById(int id);

        Ogrenci OgrenciEkle(Ogrenci ogrenci);

        Ogrenci? OgrenciGuncelle(int id, Ogrenci ogrenci);

        bool OgrenciSil(int id);    
    }
}
