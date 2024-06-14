using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreGarageSale.Data;
using Models;
using Models.DTO;

namespace AndreGarageSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly AndreGarageSaleContext _context;

        public SalesController(AndreGarageSaleContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSale()
        {
          if (_context.Sale == null)
          {
              return NotFound();
          }
            return await _context.Sale.Include(s => s.Payment).Include(s=> s.Payment.Card).Include(s=> s.Payment.Boleto).Include(s => s.Payment.Pix).Include(s => s.Payment.Pix.Type).Include(s => s.Employee).Include(s => s.Employee.Position).Include(s=> s.Employee.Adress).Include(s => s.Client).Include(s=> s.Client.Adress).Include(s => s.Car).ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
          if (_context.Sale == null)
          {
              return NotFound();
          }
            var sale = await _context.Sale.Include(s => s.Payment).Include(s => s.Payment.Card).Include(s => s.Payment.Boleto).Include(s => s.Payment.Pix).Include(s => s.Payment.Pix.Type).Include(s => s.Employee).Include(s => s.Employee.Position).Include(s => s.Employee.Adress).Include(s => s.Client).Include(s => s.Client.Adress).Include(s => s.Car).FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Sale>> PostSale(SaleDTO dto)
        //{
        //    Sale sale = new Sale(dto);
        //    sale.Payment = await _context.Payment.FindAsync(dto.PaymentId);
        //    sale.Employee = await _context.Employee.FindAsync(dto.EmployeeDocument);
        //    sale.Client = await _context.Client.FindAsync(dto.ClientDocument);
        //    sale.Car = await _context.Car.FindAsync(dto.CarPlate);


        //  if (_context.Sale == null)
        //  {
        //      return Problem("Entity set 'AndreGarageSaleContext.Sale'  is null.");
        //  }
        //    _context.Sale.Add(sale);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        //}

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            if (_context.Sale == null)
            {
                return NotFound();
            }
            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost(Name = "PostAll")]
        public async Task<ActionResult<Sale>> PostSaleAll(Sale sale)
        {
            if (_context.Sale == null)
            {
                return Problem("Entity set 'AndreGarageSaleContext.Sale'  is null.");
            }
            _context.Sale.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        private bool SaleExists(int id)
        {
            return (_context.Sale?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
