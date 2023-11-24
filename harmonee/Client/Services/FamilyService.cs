using harmonee.Shared.Helpers;
using harmonee.Shared.Models;
using System.Net.Http.Json;

namespace harmonee.Client.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IApiClient _client;

        public FamilyService(IApiClient client)
        {
            _client = client;
        }

        public async ValueTask<Family?> GetFamily(Guid id)
        {
            return await _client.GetAsync<Family>($"api/Family/{id}");
        }

        public async ValueTask<Family?> CreateFamily(Family toCreate)
        {
            return await _client.PostAsync($"api/Family", toCreate, CancellationToken.None);
        }

        public async ValueTask<bool> UpdateFamily(Family toUpdate)
        {
            return await _client.PutAsync<Family, bool>("api/Family", toUpdate, CancellationToken.None);
        }

        public async ValueTask<bool> DeleteFamily(Family toDelete)
        {
            return await _client.DeleteAsync($"api/Family/{toDelete.Id}", CancellationToken.None);
        }

        public async ValueTask<bool> AddFamilyMember(Family family, Guid userId)
        {
            return await _client.PostAsync<FamilyMember, bool>("FamilyMember", new FamilyMember { FamilyId = family.Id, UserId = userId });
        }

        public async ValueTask<bool> RemoveFamilyMember(Family family, Guid userId)
        {
            family.FamilyMemberIds = family.FamilyMemberIds.Where(fmi => fmi != userId).ToArray();
            var familyUpdated = await _client.PutAsync<Family, bool>("Family", family);
            var memberDeleted = await _client.DeleteAsync($"FamilyMember?userId={userId}&familyId={family.Id}");
            return familyUpdated && memberDeleted;
        }

        public async ValueTask<bool> AddFamilyEvent(Family family, FamilyEvent familyEvent)
        {
            family.FamilyEventIds.Append(familyEvent.Id);
            var eventCreated = await _client.PostAsync<FamilyEvent, bool>("FamilyEvent", familyEvent);
            if (eventCreated)
            {
                var familyUpdated = await _client.PutAsync<Family, bool>("Family", family);
                return familyUpdated;
            }
            return false;
        }

        public async ValueTask<bool> RemoveFamilyEvent(Family family, FamilyEvent familyEvent)
        {
            var removedFromFamily = family.RemoveFamilyEvent(familyEvent.Id);
            var familyUpdated = await _client.PutAsync<Family, bool>("Family", family);
            var eventDeleted = await _client.DeleteAsync($"FamilyEvent/{familyEvent.Id}");
            return removedFromFamily && familyUpdated && eventDeleted;
        }
    }

    public interface IFamilyService
    {
        public  ValueTask<Family?> GetFamily(Guid id);
        public  ValueTask<Family?> CreateFamily(Family toCreate);
        public  ValueTask<bool> UpdateFamily(Family toUpdate);
        public  ValueTask<bool> DeleteFamily(Family toDelete);
        public  ValueTask<bool> AddFamilyMember(Family family, Guid userId);
        public  ValueTask<bool> RemoveFamilyMember(Family family, Guid userId);
        public  ValueTask<bool> AddFamilyEvent(Family family, FamilyEvent familyEvent);
        public  ValueTask<bool> RemoveFamilyEvent(Family family, FamilyEvent familyEvent);
	}
}
