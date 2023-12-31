using harmonee.Shared.Models;

namespace harmonee.Client.Services
{
	public class FamilyListService : IFamilyListService
	{
		private readonly IApiClient _client;

		public FamilyListService(IApiClient client)
		{
			_client = client;
		}

		public async ValueTask<FamilyList?> GetFamilyList(Guid id)
		{
			return await _client.GetAsync<FamilyList>($"api/FamilyList/{id}");
		}

		public async ValueTask<IEnumerable<FamilyList>?> GetMany(IEnumerable<Guid> ids)
		{
			return await _client.PostAsync<IEnumerable<Guid>, IEnumerable<FamilyList>>("api/FamilyList", ids);
		}
		public async ValueTask<IEnumerable<FamilyList>?> GetByFamilyId(Guid familyId)
		{
			return await _client.GetAsync<IEnumerable<FamilyList>?>($"api/FamilyList/ByFamily/{familyId}");
		}

		public async ValueTask<FamilyList?> CreateFamilyList(FamilyList toCreate)
		{
			return await _client.PostAsync($"api/FamilyList", toCreate, CancellationToken.None);
		}

		public async ValueTask<bool> UpdateFamilyList(FamilyList toUpdate)
		{
			return await _client.PutAsync<FamilyList, bool>("api/FamilyList", toUpdate, CancellationToken.None);
		}

		public async ValueTask<bool> DeleteFamilyList(FamilyList toDelete)
		{
			return await _client.DeleteAsync($"api/FamilyList/{toDelete.Id}", CancellationToken.None);
		}
	}
	public interface IFamilyListService
	{
		public ValueTask<FamilyList?> GetFamilyList(Guid id);
		public ValueTask<IEnumerable<FamilyList>?> GetMany(IEnumerable<Guid> ids);
		public ValueTask<IEnumerable<FamilyList>?> GetByFamilyId(Guid familyId);
		public ValueTask<FamilyList?> CreateFamilyList(FamilyList toCreate);
		public ValueTask<bool> UpdateFamilyList(FamilyList toUpdate);
		public ValueTask<bool> DeleteFamilyList(FamilyList toDelete);
	}
}
