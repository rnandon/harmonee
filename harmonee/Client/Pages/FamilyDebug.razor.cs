using harmonee.Client.Services;
using harmonee.Shared.Models;

namespace harmonee.Client.Pages
{
	public partial class FamilyDebug
	{
  //      IFamilyService _familyService;
		//IFamilyListService _familyListService;
		//IFamilyMemberService _familyMemberService;
		//IFamilyEventService _familyEventService;

        private Guid FamilyId = new Guid();
		private Family? Family = null;
		private List<FamilyEvent> Events = new();
		private List<FamilyList> Lists = new();
		private List<FamilyMember> Members = new();

        //public FamilyDebug(IFamilyEventService familyEventService, IFamilyMemberService familyMemberService, IFamilyListService familyListService, IFamilyService familyService)
        //{
        //    _familyEventService = familyEventService;
        //    _familyMemberService = familyMemberService;
        //    _familyListService = familyListService;
        //    _familyService = familyService;
        //}

        private async Task GetEventsAsync()
		{
			var events = await _familyEventService.GetByFamilyId(FamilyId);
			if (events is not null)
			{
				Events = events.ToList();
			}
		}

		private async Task GetListsAsync()
		{
			var lists = await _familyListService.GetByFamilyId(FamilyId);
			if (lists is not null)
			{
				Lists = lists.ToList();
			}
		}

		private async Task GetMembersAsync()
		{
			var members = await _familyMemberService.GetByFamilyId(FamilyId);
			if (members is not null)
			{
				Members = members.ToList();
			}
		}
	}
}
