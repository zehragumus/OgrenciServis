using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OgrenciServis.Logic.Interface;
using OgrenciServis.Models;
using OgrenciServis.Models.DTO;
using System.Runtime.CompilerServices;

namespace OgrenciServis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrenciController : ControllerBase
    {
        private readonly IOgrenci ogrenci;

        public OgrenciController(IOgrenci ogrenci)
        {
            this.ogrenci = ogrenci;
        }

        [HttpGet]
        public ActionResult<OgrenciDto> GetOgrenciler()
        {
            return Ok(this.ogrenci.TumOgrencileriListele());
        }


        // Get: api
        [HttpGet("{id}")]

        public ActionResult<OgrenciDto> GetOgrenci(int id)

        {
            var ogrenciDto = this.ogrenci.OgrenciGetirById(id);
            if (ogrenciDto == null)
            {
                return NotFound($"Öğrenci ID {id} bulunamadı");
            }
            return Ok(ogrenciDto);
        }


        //Post: api/
        [HttpPost]

        public ActionResult<Ogrenci> PostOgrenci([FromBody] Ogrenci ogrenci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniOgrenci = this.ogrenci.OgrenciEkle(ogrenci);
            return CreatedAtAction(nameof(GetOgrenci), new { id = yeniOgrenci.OgrenciId }, yeniOgrenci);

        }
        // Put
        [HttpPut("{id}")]

        public ActionResult<Ogrenci> PutOgrenci(int id, [FromBody] Ogrenci ogrenci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guncellenebOgrenci = this.ogrenci.OgrenciGuncelle(id, ogrenci);

            if (guncellenebOgrenci == null)
            {
                return NotFound($"Öğrenci ID {id} bulunamadı");

            }
            return Ok(guncellenebOgrenci);

        }
        //Delete
        [HttpDelete("{id}")]

        public ActionResult DeleteOgrenci(int id)

        {
            var silindi = this.ogrenci.OgrenciSil(id);

            if (!silindi)

            {
                return NotFound($"Öğrenci ID {id} bulunamadı");
            }
            return NoContent();
        }



    }
}
