namespace Bookify.Domain.Bookings
{
    public class DateRange
    {
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public int LengthInDays => End.DayNumber - Start.DayNumber;

        private DateRange()
        {
        }

        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if (start > end)
            {
                throw new ArgumentException("End date procedes start date");
            }

            return new DateRange
            {
                Start = start,
                End = end
            };
        }

    }
}
