using AndreGarageFinancing.Repository;
using AndreGarageFinancing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;

namespace AndreGarageFinancing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancingControllers : ControllerBase
    {
        
        private readonly FinancingService _service;

        public FinancingControllers(FinancingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Financing>>> GetAll()
        {
            var financings = await _service.GetAll();
            if (financings == null)
            {
                return NotFound();
            }
            return financings;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Financing>> Get(int id)
        {
            var financing = await _service.Get(id);
            if (financing == null)
            {
                return NotFound();
            }
            return financing;
        }
        [HttpPost]
        public async Task<ActionResult<Financing>> Post(FinancingDTO dto)
        {
            var financing = await _service.CreateFinancing(dto);
            if (financing == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("Get", new { id = financing.Id }, financing);
        }

    }
}
