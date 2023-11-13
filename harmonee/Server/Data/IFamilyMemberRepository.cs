using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public interface IFamilyMemberRepository
    {
        public bool Add(FamilyMember entity);
        public IEnumerable<FamilyMember> AddMany(IEnumerable<FamilyMember> entities);
        public bool Delete(FamilyMember familyMember);
        public bool Delete(Guid userId, Guid familyId);
        public bool DeleteMany(IEnumerable<FamilyMember> familyMembers);
        public IEnumerable<FamilyMember> GetAll();
        public FamilyMember? GetById(Guid userId, Guid familyId);
        public IEnumerable<FamilyMember> GetByFamilyId(Guid familyId);
        public IEnumerable<FamilyMember> GetByUserId(Guid userId);
    }
}
