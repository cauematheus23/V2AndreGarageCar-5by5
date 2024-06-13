using AndreGarageSendBank.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AndreGarageSendBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendBanksController : ControllerBase
    {
        private readonly SendBankService _sendBankService;
        public SendBanksController(SendBankService sendBankService)
        {
            _sendBankService = sendBankService;
        }
        [HttpPost]
        public ActionResult<Bank> PostBank(Bank bank)
        {
            if (bank == null)
            {
                return BadRequest();
            }

            _sendBankService.Create(bank);
            return bank;
        }

    }
}

