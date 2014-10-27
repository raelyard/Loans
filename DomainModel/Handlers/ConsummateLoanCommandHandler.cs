using System;
using MediaLoanLIbrary.Loans.Common.Messages.Commands;
using MediaLoanLibrary.Loans.PublicEvents;
using NServiceBus;

namespace MediaLoanLIbrary.Loans.DomainModel.Handlers
{
    public class ConsummateLoanCommandHandler : IHandleMessages<ConsummateLoanCommand>
    {
        private const int DefaultLoanTermDays = 21;

        private readonly IBus _bus;

        public ConsummateLoanCommandHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(ConsummateLoanCommand message)
        {
            _bus.Publish<LoanConsumatedEvent>(theEvent =>
            {
                theEvent.LoanId = Guid.NewGuid();
                theEvent.DueDate = DateTime.Today.AddDays(DefaultLoanTermDays);
            });
        }
    }
}
