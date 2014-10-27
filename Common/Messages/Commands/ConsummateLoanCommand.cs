using System;

namespace MediaLoanLIbrary.Loans.Common.Messages.Commands
{
    public class ConsummateLoanCommand
    {
        public Guid ItemId { get; set; }
        public Guid PatronId { get; set; }
    }
}
