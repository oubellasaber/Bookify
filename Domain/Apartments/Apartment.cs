using Bookify.Domain.Abstraction;
using Bookify.Domain.Apartments;

namespace Bookify.Domain.Apartment
{
    public sealed class Apartment : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public decimal PriceAmount { get; private set; }
        public string PriceCurrency { get; private set; }
        public string CleaningFeeAmount { get; private set; }
        public string CleaningFeeCurrency { get; private set; }
        public DateTime? LastBookedOnUtc { get; private set; }
        public List<Amenty> Amenties { get; private set; } = new();

        public Apartment(
            Guid id,
            string name, 
            string description, 
            string country, 
            string state, 
            string zipCode, 
            string city, 
            string street, 
            decimal priceAmount, 
            string priceCurrency, 
            string cleaningFeeAmount, 
            string cleaningFeeCurrency, 
            DateTime? lastBookedOnUtc, 
            List<Amenty> amenties) 
            : base (id)
        {
            Name = name;
            Description = description;
            Country = country;
            State = state;
            ZipCode = zipCode;
            City = city;
            Street = street;
            PriceAmount = priceAmount;
            PriceCurrency = priceCurrency;
            CleaningFeeAmount = cleaningFeeAmount;
            CleaningFeeCurrency = cleaningFeeCurrency;
            LastBookedOnUtc = lastBookedOnUtc;
            Amenties = amenties;
        }
    }
}
