using System.Text;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using JasperFx.Core.Reflection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Wolverine;

namespace api.Handlers.Trello;

public class GetGoogleCalendarHandler : IWolverineHandler
{
    public async Task<Event[]> Handle(GetGoogleCalendarRequest request, IOptions<GoogleCalendarOptions> googleCalendarOptions, IMemoryCache memoryCache)
    {
        // Props to: https://stackoverflow.com/questions/40144018/access-google-calendar-api-using-service-account-authentication
        // https://www.daimto.com/google-service-accounts-with-json-file/
        var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(googleCalendarOptions.Value.ServiceEmailAccount)
        {
            Scopes = [CalendarService.Scope.Calendar]
        }.FromPrivateKey(googleCalendarOptions.Value.PrivateKey));

        // Create the Calendar service.
        var googleCalendarService = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
        });

        var events1 = await GetEventsFromCalendar(googleCalendarService, "jonno.choo@gmail.com");
        var events2 = await GetEventsFromCalendar(googleCalendarService, "joannejjma@gmail.com");

        return [.. events1, .. events2];
    }

    private async Task<IList<Event>> GetEventsFromCalendar(CalendarService googleCalendarService, string calendarId)
    {
        var request = googleCalendarService.Events.List(calendarId);
        request.MaxResults = 12;
        request.SingleEvents = true;
        request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
        request.TimeMinDateTimeOffset = DateTimeOffset.UtcNow;

        var response = await request.ExecuteAsync();
        return response.Items;
    }
}