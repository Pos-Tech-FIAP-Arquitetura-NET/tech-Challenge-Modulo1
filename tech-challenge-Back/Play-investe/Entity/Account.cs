using Play_investe.DTO;
using StoreFIAP.Entity;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Play_investe.Entity
{
    /// <summary>
    /// Representa uma Conta no sistema, contendo informações essenciais e métodos relacionados. Herda propriedade Id de Entitys
    /// </summary>
    public class Account : Entitys
    {
        public float Balance { get; set; } = 0;
        public string Agency { get; set; } = "0024";
        public string AccountNumber { get; set; }
        public string AccountType { get; set; } = "Conta Corrente";
        public List<Investment> Investments { get; set; } = new List<Investment>();
        public List<TransactionsBank> TransactionsBank { get; set; } = new List<TransactionsBank>();
        public DateTime WithdrawalAvailabilityDate { get; set; }
        public bool IsWithdrawalAvailableForAll { get; set; } = false;
        public float WithdrawalAvailableAmount { get; set; } = 0;
        public float TotalInvestimentValue { get; set; } = 0;
        public int IdUser { get; set; }
        public User User { get; set; }


        public Account() {
           
            
        }

        public Account(int iduser)
        {
            AccountNumber = this.GenerateAccountNumber();
            IdUser = iduser;
            CreatedDate = DateTime.Now;
            WithdrawalAvailabilityDate = DateTime.Now;

        }
        public string GenerateAccountNumber()
        {
            Random random = new Random();
            int accountNumber = random.Next(100000, 999999);
            return accountNumber.ToString();
        }

        public float CalculateTotalInvestmentValue()
        {
            float totalInvestment = 0;

            foreach (Investment investment in Investments)
            {
                totalInvestment += investment.Value;
            }

            TotalInvestimentValue = totalInvestment;

            return totalInvestment;
        }

        public void Withdraw(float amount)
        {
            if (amount > 0)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                }
                else
                {                    
                    throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");
                }
            }
            else
            {
                
                throw new ArgumentException("O valor de saque deve ser maior que zero.");
            }
        }


        public void Deposit(float amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                throw new ArgumentException("O valor do depósito deve ser maior que zero.");
            }
        }
    }
}