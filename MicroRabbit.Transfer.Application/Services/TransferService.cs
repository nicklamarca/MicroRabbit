using MicroRabbit.Transfer.Domain.Models;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;

namespace MicroRabbit.Banking.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            throw new NotImplementedException();
        }
    }
}
