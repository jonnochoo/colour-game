using System.Globalization;
using Google.Apis.Calendar.v3.Data;

namespace api.Handlers.GoogleCalendar;

public record EventDto
{
    public string Summary { get; set; } = null!;
    public DateTimeOffset StartDateOffset { get; set; }

    public static EventDto CreateFrom(Event evt)
    {
        DateTimeOffset? startDateOffset = evt.Start.DateTimeDateTimeOffset;
        if (startDateOffset == null)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Australia/Sydney");
            DateTime dateTime = DateTime.ParseExact(evt.Start.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            TimeSpan offset = timeZone.GetUtcOffset(dateTime);
            startDateOffset = new DateTimeOffset(dateTime, offset);
        }

        return new EventDto
        {
            Summary = evt.Summary,
            StartDateOffset = startDateOffset.Value
        };
    }
}