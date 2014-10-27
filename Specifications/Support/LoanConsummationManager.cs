using System;
using System.Collections.Generic;
using Should;

namespace MediaLoanLibrary.Loans.Specifications.Support
{
    public class LoanConsummationManager
    {
        public IDictionary<Guid, string> ExecuteSearch(string searchText)
        {
            return Search(searchText);
        }

        public Guid ExecuteBorrowItem(Guid itemId)
        {
            return CreateLoan(itemId);
        }

        public void AssertLoanExsists(Guid loanId)
        {
            loanId.ShouldNotEqual(default(Guid));
        }

        public IDictionary<Guid, string> Search(string searchText)
        {
            return new Dictionary<Guid, string>() { {Guid.Empty, "Harry Potter and the Goblet of Fire" }};
        }

        public Guid CreateLoan(Guid id)
        {
            return Guid.NewGuid();
        }
    }
}
