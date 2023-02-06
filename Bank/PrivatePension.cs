using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank
{
    public class PrivatePension : BankAccount
    {
        private readonly decimal _monthlyValue;
        private readonly decimal _feesValue;
        private readonly int _minimumYears;
        private readonly DateTime _openDateTime;
        public PrivatePension(string name, decimal initialBalance,
            decimal monthlyValue, decimal feesValue, int minimumYears, DateTime openDateTime) : 
            base(name, initialBalance)
        {
            _monthlyValue = monthlyValue;
            _feesValue = feesValue;
            _minimumYears = minimumYears;
            _openDateTime = openDateTime;
        }

        public override void PerformMonthEndTransactions()
        {
            MakeDeposit(amount: _monthlyValue, date: DateTime.Now, "Depósito do mês " + DateTime.Now.Month);
        }

        /// <summary>
        /// Valor da entrada * (Juros * Quantidade de meses que ficou investido até o momento)
        /// E então soma os valores de cada transação e seus juros.
        /// </summary>
        public override decimal Balance {
            get
            {
                decimal balance = 0;
                foreach (var item in transactions)
                {
                    var months = 1;
                    var DateTimeAux = item.Date;
                    while(DateTimeAux < DateTime.Now)
                    {
                        months++;
                        DateTimeAux = DateTimeAux.AddMonths(1);
                    }

                    balance += item.Amount * (_feesValue * months);
                }

                return balance;
            }
        }

        public override void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            DateTime finalDate = _openDateTime.AddYears(_minimumYears);
            var totalAmount = 0m;

            if (DateTime.Now < finalDate)
            {
                var totalMonths = (finalDate.Year - DateTime.Now.Year);
                var fee = 20 / _minimumYears;

                totalAmount = Balance - (Balance * fee);
            }
            else
            {
                totalAmount = Balance;
            }

            var balanceAfterFees = Balance - totalAmount;

            base.MakeWithdrawal(totalAmount, date, note);

            MakeDeposit(-balanceAfterFees, DateTime.Now, "Juros do banco");
        }
    }
}
