using OgrenciServis.Models;
using OgrenciServis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Interface
{
    public interface IDers
    {
        IEnumerable<DersDto> TumDersleriListele();

        DersDto? DersGetirById(int id);

        Ders DersEkle(Ders ders);

        Ders? DersGuncelle(int id, Ders ders);

        bool DersSil(int id);
    }
}
