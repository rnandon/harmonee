using Harmonee.Shared.Utilities;

namespace Harmonee.UI.Services;

public class CalendarService
{
    private readonly HarmoneeHttpClient _client;

    public CalendarService(HarmoneeHttpClient client)
    {
        _client = client;
    }
}
