using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Conta de cartão de presente.
    /// Pode ser preenchido novamente com um valor especializado uma vez por mês,
    /// no último dia do mês
    /// </summary>
    public class GiftCardAccount : BankAccount
    {
        private readonly decimal _monthlyDeposit = 0m;
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : 
            base(name, initialBalance)
        {
            _monthlyDeposit = monthlyDeposit;
        }

        public override void PerformMonthEndTransactions()
        {
            MakeDeposit(amount: _monthlyDeposit, date: DateTime.Now, note: "Adicionando " +
                "depósito mensal.");
        }
    }
}
