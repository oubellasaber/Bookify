using System.Runtime.ExceptionServices;

namespace Bookify.Domain.Shared
{
    public record Money(decimal Amount, Currency Currency)
    {
        public static Money operator +(Money lfh, Money rhs)
        {
            if (lfh.Currency != rhs.Currency)
            {
                throw new InvalidOperationException("Currencies have to be equal");
            }

            return new Money(lfh.Amount + rhs.Amount, rhs.Currency);
        }

        public static Money Zero(Currency currency) => new Money(0, currency);

        public bool IsZero() => this == Zero(Currency);
    }
}
