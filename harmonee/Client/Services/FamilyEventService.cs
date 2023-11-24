using harmonee.Shared.Models;

namespace harmonee.Client.Services
{
	public class FamilyEventService
	{
		private readonly IApiClient _client;

		public FamilyEventService(IApiClient client)
		{
			_client = client;
		}

		public async ValueTask<FamilyEvent?> GetFamilyEvent(Guid id)
		{
			return await _client.GetAsync<FamilyEvent>($"api/FamilyEvent/{id}");
		}

		public async ValueTask<IEnumerable<FamilyEvent>?> GetByFamilyId(Guid familyId)
		{
			return await _client.GetAsync<IEnumerable<FamilyEvent>>($"api/FamilyEvent/ByFamily/{familyId}");
		}

		public async ValueTask<FamilyEvent?> CreateFamilyEvent(FamilyEvent toCreate)
		{
			return await _client.PostAsync($"api/FamilyEvent", toCreate, CancellationToken.None);
		}

		public async ValueTask<bool> UpdateFamilyEvent(FamilyEvent toUpdate)
		{
			return await _client.PutAsync<FamilyEvent, bool>("api/FamilyEvent", toUpdate, CancellationToken.None);
		}

		public async ValueTask<bool> DeleteFamilyEvent(FamilyEvent toDelete)
		{
			return await _client.DeleteAsync($"api/FamilyEvent/{toDelete.Id}", CancellationToken.None);
		}
	}

	public interface IFamilyEventService
	{
		public ValueTask<FamilyEvent?> GetFamilyEvent(Guid id);
		public ValueTask<IEnumerable<FamilyEvent>?> GetByFamilyId(Guid familyId);
		public ValueTask<FamilyEvent?> CreateFamilyEvent(FamilyEvent toCreate);
		public ValueTask<bool> UpdateFamilyEvent(FamilyEvent toUpdate);
		public ValueTask<bool> DeleteFamilyEvent(FamilyEvent toDelete);
	}
}
