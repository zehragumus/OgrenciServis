using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OgrenciServis.Logic.Interface;
using OgrenciServis.Models;
using OgrenciServis.Models.DTO;

namespace OgrenciServis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgretmenController : ControllerBase
    {
        private readonly IOgretmen ogretmen;

        public OgretmenController(IOgretmen ogretmen)
        {
            this.ogretmen = ogretmen;
        }

        [HttpGet]

        public ActionResult GetOgretmenler()
        {
            return Ok(this.ogretmen.TumOgretmenleriListele());

        }
        // Get: api
        [HttpGet("{id}")]

        public ActionResult<OgretmenDto> GetOgretmen(int id)

        {
            var ogretmenDto = this.ogretmen.OgretmenGetirById(id);
            if (ogretmenDto == null)
            {
                return NotFound($"Öğretmen ID {id} bulunamadı");
            }
            return Ok(ogretmenDto);
        }


        //Post: api/
        [HttpPost]

        public ActionResult<Ogretmen> PostOgretmen([FromBody] Ogretmen ogretmen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yeniOgretmen = this.ogretmen.OgretmenEkle(ogretmen);
            return CreatedAtAction(nameof(GetOgretmen), new { id = yeniOgretmen.OgretmenId }, yeniOgretmen);

        }
        // Put
        [HttpPut("{id}")]

        public ActionResult<Ogretmen> PutOgretmen(int id, [FromBody] Ogretmen ogretmen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guncellenebOgretmen = this.ogretmen.OgretmenGuncelle(id, ogretmen);

            if (guncellenebOgretmen == null)
            {
                return NotFound($"Öğretmen ID {id} bulunamadı");

            }
            return Ok(guncellenebOgretmen);

        }
        //Delete
        [HttpDelete("{id}")]

        public ActionResult DeleteOgretmen(int id)

        {
            var silindi = this.ogretmen.OgretmenSil(id);

            if (!silindi)

            {
                return NotFound($"Öğretmen ID {id} bulunamadı");
            }
            return NoContent();
        }

    }
}
