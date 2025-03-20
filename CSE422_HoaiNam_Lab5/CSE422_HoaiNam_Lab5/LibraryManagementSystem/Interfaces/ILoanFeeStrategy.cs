using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_HoaiNam_Lab5.LibraryManagementSystem.Interfaces
{
    public interface ILoanFeeStrategy
    {
        decimal CalculateFee(int days);
    }
}
