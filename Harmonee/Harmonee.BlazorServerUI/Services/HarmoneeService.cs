using Harmonee.Shared.Utilities;

namespace Harmonee.UI.Services;

public class HarmoneeService
{
    private readonly HarmoneeHttpClient _client;
    public readonly GroupService Group;
    public readonly GroupListService List;
    public readonly GroupMemberService Member;
    public readonly CalendarService Calendar;

    public HarmoneeService(HarmoneeHttpClient client)
    {
        _client = client;
        Group = new GroupService(_client);
        List = new GroupListService(_client);
        Member = new GroupMemberService(_client);
        Calendar = new CalendarService(_client);
    }
}
