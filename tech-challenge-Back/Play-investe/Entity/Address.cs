using Play_investe.Entity;

namespace Play_investe.Entity
{
    public class Address : Entitys
    {       
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }

        public Address() { }

        public Address(string street, string number, string zipCode, string city, string state, string country, int idUser)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
            State = state;
            IdUser = idUser;
            Country = country;
            CreatedDate = DateTime.Now;
        }

    }
}
