using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Conta de linha de crédito.
    /// Pode ter um saldo negativo, mas não ser maior em valor absoluto do que o limite
    /// de crédito
    /// </summary>
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : 
            base(name, initialBalance, minimunBalance: -creditLimit)
        {
            if(Balance < 0)
            {
                decimal juros = -Balance * 0.07m;
                MakeWithdrawal(amount: juros, date: DateTime.Now, note: "Retirada dos juros mensal.");
            }
        }
    }
}

