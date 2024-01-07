using Play_investe.Entity;

namespace Play_investe.Entity
{
    public class TransactionsBank :  Entitys
    {     

        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Type { get; set; }
        public int SourceAccountId { get; set; }  
        public int DestinationAccountId { get; set; }
        public int IdAccount { get; set; }
        public Account Account { get; set; }

        public TransactionsBank() { }

        public TransactionsBank(DateTime date, float amount, string type, int sourceAccountId, int destinationAccountId)
        {
            Date = date;
            Amount = amount;
            Type = type;            
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
            CreatedDate = DateTime.Now;
        }


    }
}
