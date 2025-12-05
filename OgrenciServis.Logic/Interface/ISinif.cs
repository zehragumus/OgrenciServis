using OgrenciServis.Models;
using OgrenciServis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Interface
{
    public interface ISinif
    {
        IEnumerable<SinifDto> TumSiniflariListele();

        SinifDto? SinifGetirById(int id);

        Sinif SinifEkle(Sinif sinif);

        Sinif? SinifGuncelle(int id, Sinif sinif);

        bool SinifSil(int id);

    }
}
