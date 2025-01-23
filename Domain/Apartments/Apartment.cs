using Bookify.Domain.Abstraction;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Apartments
{
    public sealed class Apartment : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Address Address { get; private set; }
        public Money Price { get; private set; }
        public Money CleaningFee { get; private set; }
        public DateTime? LastBookedOnUtc { get; internal set; }
        public List<Amenity> Amenities { get; private set; } = new();

        public Apartment(
            Guid id,
            string name, 
            string description, 
            Address address,
            Money price, 
            Money cleaningFee, 
            DateTime? lastBookedOnUtc, 
            List<Amenity> amenties)
            : base (id)
        {
            Name = name;
            Description = description;
            Address = address;
            Price = price;
            CleaningFee = cleaningFee;            
            LastBookedOnUtc = lastBookedOnUtc;
            Amenities = amenties;
        }
    }
}
