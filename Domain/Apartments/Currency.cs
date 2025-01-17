namespace Bookify.Domain.Apartments
{
    public record Currency
    {
        internal static readonly Currency None = new("");
        public static readonly Currency Usd = new("USD");
        public static readonly Currency Mad = new("MAD");

        public string Code { get; private set; }

        private Currency(string code)
        {
            Code = code;
        }

        public static readonly IReadOnlyCollection<Currency> All = new[] { Usd, Mad };

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == "code") ??
                throw new ArgumentException($"The currency code is invalid");
        }
    }
}
