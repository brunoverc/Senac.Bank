using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount
    {
        private readonly decimal _minimunBalance;
        public BankAccount(string name, decimal initialBalance) :
            this(name, initialBalance, 0)
        { }
        public BankAccount(string name, decimal initialBalance, decimal minimunBalance)
        {
            _minimunBalance = minimunBalance;
            Owner = name;
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            MakeDeposit(initialBalance, DateTime.Now, "Depósito inicial");
        }

        private static int accountNumberSeed = 1234567890;

        public string Number { get; set; }
        public string Owner { get; set; }
        public virtual decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in transactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        public List<Transaction> transactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), 
                    message: "O valor para o depósito precisa ser positivo.");
            }

            Transaction deposit = new Transaction(amount, date, note);
            transactions.Add(deposit);
        }

        public virtual void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(Balance - amount < _minimunBalance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    message: "O valor para o saque precisa ser positivo.");
            }

            //if(Balance - amount < 0)
            //{
            //    throw new InvalidOperationException(message: "Saldo insuficiente para a retirada.");
            //}

            Transaction withdrawal = new Transaction(-amount, date, note);
            transactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            decimal balance = 0;
            report.AppendLine("Data\t\tValor\tSaldo\tNota");
            foreach(var item in transactions)
            {
                balance += item.Amount;
                string line = $"{item.Date.ToShortDateString()}\t" +
                    $"{item.Amount}\t{balance}\t{item.Notes}";

                report.AppendLine(line);
            }
            return report.ToString();
        }

        public virtual void PerformMonthEndTransactions() { }
    }
}
