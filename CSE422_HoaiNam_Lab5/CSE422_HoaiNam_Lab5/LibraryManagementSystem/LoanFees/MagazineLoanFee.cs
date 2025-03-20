using CSE422_HoaiNam_Lab5.LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.LoanFees
{
    public class MagazineLoanFee : ILoanFeeStrategy
    {
        public decimal CalculateFee(int days) => days * 2.0m;
    }
}
