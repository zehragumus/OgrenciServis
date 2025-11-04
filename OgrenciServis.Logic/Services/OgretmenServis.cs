using OgrenciServis.DataAccess;
using OgrenciServis.Logic.Interface;
using OgrenciServis.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciServis.Logic.Services
{
    public class OgretmenServis : Interface.IOgretmen
    {
        private readonly OkulContext _context;

        public OgretmenServis(OkulContext context)
        {
            _context = context;
        }

        public IEnumerable<OgretmenDto> TumOgretmenleriListele()
        {
            try
            {
                var sonuc = from ogretmen in _context.Ogretmenler
                            join sinif in _context.Siniflar on ogretmen.Sinif equals sinif.SinifId
                            select new OgretmenDto
                            {
                                OgretmenId = ogretmen.OgretmenId,
                                Adi = ogretmen.OgretmenAdi,
                                Soyadi = ogretmen.OgretmenSoyadi,
                                Sube = sinif.Sube,
                                SinifNo = sinif.SinifNo,
                                Brans = ogretmen.Brans
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
