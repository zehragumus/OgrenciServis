using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OgrenciServis.Logic.Interface;
using OgrenciServis.Models;
using OgrenciServis.Models.DTO;
using OgrenciServis.Models.Exceptions;
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
        [AllowAnonymous]

        public ActionResult<OgrenciDto> GetOgrenci(int id)

        {
            try
            {
                var ogrenciDto = this.ogrenci.OgrenciGetirById(id);
                return Ok(ogrenciDto);

            }
            catch (NotFoundException ex)
            { 
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

               // return StatusCode(500, "Bilinmeyen bir hata oluştu" + ex.Message) ;
                return StatusCode(500, $"Bilinmeyen bir hata oluştu { ex.Message} {id}") ;


            }






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
