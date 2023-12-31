using harmonee.Shared.Models;

namespace harmonee.Client.Services
{
	public class FamilyMemberService : IFamilyMemberService
	{
		private readonly IApiClient _client;

		public FamilyMemberService(IApiClient client)
		{
			_client = client;
		}

		public async ValueTask<FamilyMember?> GetFamilyMember(Guid id)
		{
			return await _client.GetAsync<FamilyMember>($"api/FamilyMember/{id}");
		}

		public async ValueTask<IEnumerable<FamilyMember>?> GetByFamilyId(Guid familyId)
		{
			return await _client.GetAsync<IEnumerable<FamilyMember>>($"api/FamilyMember/{familyId}/allMembers");
		}

		public async ValueTask<IEnumerable<FamilyMember>?> GetByUserId(Guid userId)
		{
			return await _client.GetAsync<IEnumerable<FamilyMember>>($"api/FamilyMember/{userId}/allFamilies");
		}

		public async ValueTask<FamilyMember?> CreateFamilyMember(FamilyMember toCreate)
		{
			return await _client.PostAsync($"api/FamilyMember", toCreate, CancellationToken.None);
		}

		public async ValueTask<bool> DeleteFamilyMember(FamilyMember toDelete)
		{
			return await _client.DeleteAsync($"api/FamilyMember?userId={toDelete.UserId}&familyId={toDelete.FamilyId}", CancellationToken.None);
		}
	}
	public interface IFamilyMemberService
	{
		public ValueTask<FamilyMember?> GetFamilyMember(Guid id);
		public ValueTask<IEnumerable<FamilyMember>?> GetByFamilyId(Guid familyId);
		public ValueTask<IEnumerable<FamilyMember>?> GetByUserId(Guid userId);
		public ValueTask<FamilyMember?> CreateFamilyMember(FamilyMember toCreate);
		public ValueTask<bool> DeleteFamilyMember(FamilyMember toDelete);
	}
}
