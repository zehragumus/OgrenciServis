using OgrenciServis.DataAccess;
using OgrenciServis.Logic.Interface;
using OgrenciServis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Services
{
    public class OgrenciServisImpl :IOgrenci
    {
        private readonly OkulContext _context;

        public OgrenciServisImpl(OkulContext context)   
        {
            _context = context;
        }
        public IEnumerable<OgrenciDto> TumOgrencileriListele()
        {
            try
            {
                var sonuc = from ogrenci in _context.Ogrenciler
                            join sinif in _context.Siniflar on ogrenci.SinifId equals sinif.SinifId
                            select new OgrenciDto
                            {
                                OgrenciId = ogrenci.OgrenciId,
                                Adi = ogrenci.Adi,
                                Soyadi = ogrenci.Soyadi,
                                DogumTarihi = ogrenci.DogumTarihi,
                                Sube = sinif.Sube,
                                SinifNo = sinif.SinifNo
                            };
                return sonuc.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
