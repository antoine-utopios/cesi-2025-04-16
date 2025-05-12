using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isp.Exercice05.Interfaces
{
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void RequestLoan(decimal amount);
        void OpenCreditLine(decimal amount);
    }

}
