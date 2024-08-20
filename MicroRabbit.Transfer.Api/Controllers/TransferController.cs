using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        // GET: api/Transfer
        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> GetTransferlogs()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
