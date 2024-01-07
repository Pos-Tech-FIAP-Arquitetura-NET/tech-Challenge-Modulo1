using Play_investe.Enums;

namespace Play_investe.DTO
{
    public class SaveInvestmentDTO
    {
        public string Type { get; set; }
        public float Value { get; set; }       
        public DateTime AvailabilityDate { get; set; }
        public DateTime AquisitionDate { get; set; }
      
    }
}
