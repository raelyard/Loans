using System;
using System.Collections.Generic;
using System.Linq;
using MediaLoanLibrary.Loans.Specifications.Support;
using TechTalk.SpecFlow;

namespace MediaLoanLibrary.Loans.Specifications.StepDefinitions
{
    [Binding]
    public class AcquireLoanStepDefinitions
    {
        private readonly LoanConsummationManager _loanConsummationManager;
        private IDictionary<Guid, string> _searchResults;
        private Guid _loanId;

        public AcquireLoanStepDefinitions(LoanConsummationManager loanConsummationManager)
        {
            _loanConsummationManager = loanConsummationManager;
        }

        [Given(@"I have searched and found ""(.*)""")]
        public void GivenIHaveSearchedAndFound(string itemTitle)
        {
            _searchResults = _loanConsummationManager.ExecuteSearch(itemTitle);
        }

        [When(@"I choose ""Borrow""")]
        public void WhenIChooseBorrow()
        {
            _loanId = _loanConsummationManager.ExecuteBorrowItem(_searchResults.Keys.First());
        }

        [Then(@"I should have a loan")]
        public void ThenIShouldHaveALoan()
        {
            _loanConsummationManager.AssertLoanExsists(_loanId);
        }
    }
}
