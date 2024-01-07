using Play_investe.Entity;

namespace Play_investe.DTO
{
    public class SaveAccountDTO
    {
        public float Balance { get; set; }
        public string Agency { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public List<Investment> Investments { get; set; }
        public DateTime WithdrawalAvailabilityDate { get; set; }
        public bool IsWithdrawalAvailableForAll { get; set; }
        public float WithdrawalAvailableAmount { get; set; }
    }
}
