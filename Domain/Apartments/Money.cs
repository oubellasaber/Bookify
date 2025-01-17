using System.Runtime.ExceptionServices;

namespace Bookify.Domain.Apartments
{
    public record Money(decimal Amount, Currency currency)
    {
        public static Money operator +(Money lfh, Money rhs)
        {
            if (lfh.currency != rhs.currency)
            {
                throw new InvalidOperationException("Currencies have to be equal");
            }

            return new Money(lfh.Amount + rhs.Amount, rhs.currency);
        }

        public static Money Zero = new Money(0, Currency.None);
    }
}
