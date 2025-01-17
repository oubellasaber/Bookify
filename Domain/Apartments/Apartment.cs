using Bookify.Domain.Abstraction;
using Bookify.Domain.Apartments;

namespace Bookify.Domain.Apartment
{
    public sealed class Apartment : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Address Address { get; private set; }
        public Money PriceAmount { get; private set; }
        public Currency PriceCurrency { get; private set; }
        public Money CleaningFeeAmount { get; private set; }
        public Currency CleaningFeeCurrency { get; private set; }
        public DateTime? LastBookedOnUtc { get; private set; }
        public List<Amenty> Amenties { get; private set; } = new();

        public Apartment(
            Guid id,
            string name, 
            string description, 
            Address address,
            Money priceAmount, 
            Currency priceCurrency, 
            Money cleaningFeeAmount, 
            Currency cleaningFeeCurrency, 
            DateTime? lastBookedOnUtc, 
            List<Amenty> amenties) 
            : base (id)
        {
            Name = name;
            Description = description;
            Address = address;
            PriceAmount = priceAmount;
            PriceCurrency = priceCurrency;
            CleaningFeeAmount = cleaningFeeAmount;
            CleaningFeeCurrency = cleaningFeeCurrency;
            LastBookedOnUtc = lastBookedOnUtc;
            Amenties = amenties;
        }
    }
}
