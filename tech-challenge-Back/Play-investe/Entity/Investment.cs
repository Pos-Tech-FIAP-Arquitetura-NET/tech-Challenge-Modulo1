using Play_investe.DTO;
using Play_investe.Enums;
using StoreFIAP.Entity;

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

        public Investment(SaveInvestmentDTO saveInvestimentDto)
        {
            
            Value = saveInvestimentDto.Value;          
            DueDate = saveInvestimentDto.AvailabilityDate;
            AquisitionDate = saveInvestimentDto.AquisitionDate;
            CreatedDate = DateTime.Now;


        }      




    }
}