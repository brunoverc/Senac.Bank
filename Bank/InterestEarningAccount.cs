using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Essa conta ganha juros.
    /// Irá obter um crédito de 2% do saldo final de mês
    /// </summary>
    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {

        }

        public override void PerformMonthEndTransactions()
        {
            if(Balance > 500m)
            {
                decimal interest = Balance * 0.05m;
                MakeDeposit(amount: interest, date: DateTime.Now, note: "Aplicando juros mensal");
            }
        }
    }
}
