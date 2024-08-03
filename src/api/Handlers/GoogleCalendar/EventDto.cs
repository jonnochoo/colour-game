using System.Globalization;
using Google.Apis.Calendar.v3.Data;

namespace api.Handlers.GoogleCalendar;

public record EventDto
{
    public string Summary { get; init; } = null!;
    public DateTimeOffset StartDateOffset { get; init; }
    public bool IsWeekend { get; init; }
    public bool IsAllDay { get; init; }

    public static EventDto CreateFrom(Event evt)
    {
        DateTimeOffset? startDateOffset = evt.Start.DateTimeDateTimeOffset;
        bool isAllDay = false;
        if (startDateOffset == null)
        {
            isAllDay = true;
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Australia/Sydney");
            DateTime dateTime = DateTime.ParseExact(evt.Start.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            TimeSpan offset = timeZone.GetUtcOffset(dateTime);
            startDateOffset = new DateTimeOffset(dateTime, offset);
        }


        return new EventDto
        {
            Summary = evt.Summary,
            StartDateOffset = startDateOffset.Value,
            IsAllDay = isAllDay,
            IsWeekend = startDateOffset.Value.DayOfWeek == DayOfWeek.Saturday || startDateOffset.Value.DayOfWeek == DayOfWeek.Sunday
        };
    }
}