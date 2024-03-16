using Harmonee.Shared.Utilities;

namespace Harmonee.UI.Services;

public class GroupListService
{
    private readonly HarmoneeHttpClient _client;

    public GroupListService(HarmoneeHttpClient client)
    {
        _client = client;
    }
}
