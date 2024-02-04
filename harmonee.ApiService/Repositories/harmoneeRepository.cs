using harmonee.Shared.Models;

namespace harmonee.ApiService.Repositories;

public class harmoneeRepository
{
    private readonly GroupRepository _groups;
    private readonly GroupMemberRepository _groupMembers;
    private readonly GroupListRepository _groupLists;
    private readonly CalendarEventRepository _calendarEvents;

    public harmoneeRepository(
        GroupRepository groupRepo,
        GroupMemberRepository membersRepo,
        GroupListRepository listsRepo,
        CalendarEventRepository calendarsRepo)
    {
        _groups = groupRepo;
        _groupMembers = membersRepo;
        _groupLists = listsRepo;
        _calendarEvents = calendarsRepo;
    }
}
