using AndreGarageBank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using RabbitMQ.Client;

namespace AndreGarageBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly BankService _bankService;
        private readonly BankRabbit _bankRabbit;
        private readonly ConnectionFactory _factory;

        public BanksController(BankService bank,BankRabbit bankRabbit, ConnectionFactory factory)
        {
            _bankService = bank;
            _bankRabbit = bankRabbit;
            _factory = factory;
        }

        [HttpGet]
        public ActionResult<List<Bank>> GetAll() =>
            _bankService.GetAll();

        [HttpGet("{cnpj}")]
        public ActionResult<Bank> Get(string cnpj)
        {
            var bank = _bankService.Get(cnpj);

            if (bank == null)
            {
                return NotFound();
            }

            return bank;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Bank bank)
        {
            _bankService.Create(_bankRabbit.PostBank(_factory,bank));

            return Accepted();
        }
        [HttpPut("{cnpj}")]
        public IActionResult Update(string cnpj, Bank bankIn)
        {
            var bank = _bankService.Get(cnpj);

            if (bank == null)
            {
                return NotFound();
            }
            _bankService.Update(bankIn);
            return NoContent();
        }
        [HttpDelete("{cnpj}")]
        public IActionResult Delete(string cnpj)
        {
            var bank = _bankService.Get(cnpj);

            if (bank == null)
            {
                return NotFound();
            }

            _bankService.Remove(bank);

            return NoContent();
        }
    }
}
