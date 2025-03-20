using CSE422_HoaiNam_Lab5.LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.LoanFees
{
    public class LoanFeeCalculator
    {
        private ILoanFeeStrategy _strategy;

        public LoanFeeCalculator(ILoanFeeStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ILoanFeeStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal GetLoanFee(int days)
        {
            return _strategy.CalculateFee(days);
        }
    }
}
