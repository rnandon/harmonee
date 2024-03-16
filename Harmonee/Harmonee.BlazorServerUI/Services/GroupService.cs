using Harmonee.Shared.Utilities;

namespace Harmonee.UI.Services;

public class GroupService
{
    private readonly HarmoneeHttpClient _client;

    public GroupService(HarmoneeHttpClient client)
    {
        _client = client;
    }


}
