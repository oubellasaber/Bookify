using Bookify.Domain.Abstraction;
using Bookify.Domain.Events;

namespace Bookify.Domain.Users
{
    public sealed class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        // Private constructor to enforce the use of the factory method for object creation
        private User(Guid id, string firstName, string lastName, string email)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        // Factory method to create a new User instance.
        // This method allows for raising domain events, such as UserCreated, if needed in the future.
        // Raising domain events in the constructor would violate the Separation of Concerns (SoC) principle,
        // so we keep the constructor private and use this static method to create User objects and trigger events.
        public static User Create(string firstName, string lastName, string email)
        {
            var user = new User(Guid.NewGuid(), firstName, lastName, email);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }
    }
}
