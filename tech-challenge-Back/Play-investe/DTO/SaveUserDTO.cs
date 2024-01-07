using Play_investe
    .Enums;

namespace Play_investe.DTO
{
    public class SaveUserDTO
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RG { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public PermitionsTypes Permitions { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


    }
}
