using Play_investe.DTO;
using Play_investe.Enums;
using Play_investe.Entity;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Play_investe.Entity
{
    public class Investment : Entitys
    {       
        public float Value { get; set; }
        public float Amount { get; set; }
        public DateTime DueDate { get; set; }  
        public DateTime AquisitionDate { get; set; }       
        public Bound Bound { get; set; }
        public int IdAccount { get; set; }
        public Account Account{ get; set; }

        public int IdBound { get; set; }

        public Investment() { }

        public Investment(DateTime dueDate, float value, Bound bound, Account account)
        {
            
            Value = value;
            DueDate = dueDate;
            AquisitionDate = DateTime.Now;           
            IdAccount = account.Id;
            IdBound = bound.Id;
            Bound = bound;
            Account = account;
            UpdateAmount(value);

        }

        private void UpdateAmount(float value)
        {            
            Amount += value;
        }

       




    }
}