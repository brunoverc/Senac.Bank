using Bank;

//Teste de criaçãoi de uma conta invalida
try
{
    var giftCard = new GiftCardAccount(name: "Conta presente Filho", 
        initialBalance: 100, monthlyDeposit: 50);
    giftCard.MakeWithdrawal(amount: 20, date: DateTime.Now, note: "Mesada Janeiro");
    giftCard.MakeWithdrawal(amount: 50, date: DateTime.Now, note: "Mesada Fevereiro");
    giftCard.PerformMonthEndTransactions();
    //Faço um depósito adicional
    giftCard.MakeDeposit(amount: 27.50m, date: DateTime.Now, note: "Depósito adicional");
    

    var investmentAccount = new InterestEarningAccount(name: "Conta de investimento",
        initialBalance: 10000);
    investmentAccount.MakeWithdrawal(amount: 1000m, date: DateTime.Now,
        note: "Retirada mensal avançada");
    investmentAccount.MakeDeposit(amount: 50m, date: DateTime.Now,
        note: "Recebimento de um amigo");
    investmentAccount.MakeWithdrawal(amount: 5000m, date: DateTime.Now,
        note: "Retirada de emergência");
    investmentAccount.MakeDeposit(amount: 500m, date: DateTime.Now,
        note: "Valor de retorno parcial");
    investmentAccount.PerformMonthEndTransactions();

    var lineOfCredit = new LineOfCreditAccount(name: "Conta de linha de crédito", 
        initialBalance: 0, creditLimit: 5000m);
    lineOfCredit.MakeWithdrawal(amount: 1000m, date: DateTime.Now,
        note: "Fazendo uma retirada avançada");
    lineOfCredit.MakeDeposit(amount: 50m, date: DateTime.Now,
        note: "Retorno pequeno");
    lineOfCredit.MakeWithdrawal(amount: 500m, date: DateTime.Now,
        note: "Retirada emergencial");
    lineOfCredit.MakeDeposit(amount: 150m, date: DateTime.Now,
        note: "Retorno de fundos parcial");

    lineOfCredit.PerformMonthEndTransactions();
    Console.WriteLine(lineOfCredit.GetAccountHistory());

}
catch(ArgumentOutOfRangeException e)
{
    Console.WriteLine("Ocorreu um erro ao tentar fazer o depósito. Erro: " + e.Message);
}
catch(InvalidOperationException e)
{
    Console.WriteLine("Ocorreu um erro ao fazer uma retirada. Erro: " + e.Message);
}
catch (Exception)
{
    Console.WriteLine("Ocorreu um erro genérico!");
}

void SetAccount_1()
{
    var account = new BankAccount(name: "Bruno", initialBalance: 1000);

    account.MakeWithdrawal(amount: 500, date: DateTime.Now, note: "Pagamento");
    //Console.WriteLine(account.Balance);
    account.MakeDeposit(amount: 100, date: DateTime.Now, note: "Um amigo me pagou");
    //Console.WriteLine(account.Balance);

    Console.WriteLine(account.GetAccountHistory());
}