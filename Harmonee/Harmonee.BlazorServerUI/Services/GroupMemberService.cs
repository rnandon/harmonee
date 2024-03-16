using Harmonee.Shared.Utilities;

namespace Harmonee.UI.Services;

public class GroupMemberService
{
    private readonly HarmoneeHttpClient _client;

    public GroupMemberService(HarmoneeHttpClient client)
    {
        _client = client;
    }
}
