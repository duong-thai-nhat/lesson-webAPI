using Microsoft.AspNetCore.Mvc;
using WebAPIApp.Models;
using WebAPIApp.Services;

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public IHangHoaService hangHoaService;

        public HangHoaController(IHangHoaService hangHoaService)
        {
            this.hangHoaService = hangHoaService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoaService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = hangHoaService.GetById(id);
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hangHoa = hangHoaService.Create(hangHoaVM);
            return Ok(new
            {
                Success = true,
                Data = hangHoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = hangHoaService.Update(id, hangHoaEdit);
                if (hangHoa == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                if (id == null)
                    return BadRequest();
                var hangHoa = hangHoaService.Delete(id);
                if (hangHoa == null)
                    return NotFound();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}