using harmonee.Shared.Data;
using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace harmonee.Server.Data
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly FamilyContext _context;

        public FamilyRepository(FamilyContext context)
        {
            _context = context;
        }

        public Family Add(Family entity)
        {
            entity.Id = new Guid();
            _context.Families.Add(new FamilyRecord { Id = entity.Id, Name = entity.Name });
            foreach (var familyMemberId in entity.FamilyMemberIds)
            {
                _context.FamilyMembers.Add(new FamilyMember { FamilyId = entity.Id, UserId = familyMemberId });
            }

            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<Family> AddMany(IEnumerable<Family> entities)
        {
            var familyRecords = entities.Select(e => new FamilyRecord { Id = e.Id, Name = e.Name });
            var newFamilyMembers = entities.SelectMany(e => e.FamilyMemberIds.Select(fmi => new FamilyMember { FamilyId = e.Id, UserId = fmi }));
            _context.Families.AddRange(familyRecords);
            _context.FamilyMembers.AddRange(newFamilyMembers);
            _context.SaveChanges();
            return entities;
        }

        public bool Delete(Guid id)
        {
            var familyRecord = _context.Families.FirstOrDefault(f => f.Id == id);
            if (familyRecord is null) return false;

            var familyMembersToRemove = _context.FamilyMembers.Where(fm => fm.FamilyId == familyRecord.Id);
            var familyEventsToRemove = _context.FamilyEvents.Where(fe => fe.FamilyId == familyRecord.Id);
            var familyListsToRemove = _context.FamilyLists.Where(fl => fl.FamilyId == familyRecord.Id);
            _context.FamilyMembers.RemoveRange(familyMembersToRemove);
            _context.FamilyEvents.RemoveRange(familyEventsToRemove);
            _context.FamilyLists.RemoveRange(familyListsToRemove);
            _context.Families.Remove(familyRecord);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteMany(IEnumerable<Guid> ids)
        {
            var familiesToRemove = _context.Families.Where(f => ids.Contains(f.Id));
            foreach (var familyRecord in familiesToRemove)
            {
                var familyMembersToRemove = _context.FamilyMembers.Where(fm => fm.FamilyId == familyRecord.Id);
                var familyEventsToRemove = _context.FamilyEvents.Where(fe => fe.FamilyId == familyRecord.Id);
                var familyListsToRemove = _context.FamilyLists.Where(fl => fl.FamilyId == familyRecord.Id);
                _context.FamilyMembers.RemoveRange(familyMembersToRemove);
                _context.FamilyEvents.RemoveRange(familyEventsToRemove);
                _context.FamilyLists.RemoveRange(familyListsToRemove);
            }
            if (familiesToRemove.Count() > 0)
            {
                _context.Families.RemoveRange(familiesToRemove);
                _context.SaveChanges(); 
                return true;
            }

            return false;
        }

        public IEnumerable<Family> GetAll()
        {
            var result = new List<Family>();
            var allFamilyRecords = _context.Families.Where(f => true);
            foreach (var familyRecord in allFamilyRecords)
            {
                var familyMemberIds = _context.FamilyMembers.Where(fm => fm.FamilyId == familyRecord.Id).Select(fm => fm.UserId).ToArray();
                var familyEventIds = _context.FamilyEvents.Where(fe => fe.FamilyId == familyRecord.Id).Select(e => e.Id).ToArray();
                var familyListIds = _context.FamilyLists.Where(fl => fl.FamilyId == familyRecord.Id).Select(l => l.Id).ToArray();
                result.Add(new Family
                {
                    Id = familyRecord.Id,
                    Name = familyRecord.Name,
                    FamilyMemberIds = familyMemberIds,
                    FamilyEventIds = familyEventIds,
                    FamilyListIds = familyListIds
                });
            }
            return result;
        }

        public Family? GetById(Guid id)
        {
            var familyRecord = _context.Families.FirstOrDefault(f => f.Id == id);
            if (familyRecord is null) return null;

            var familyMemberIds = _context.FamilyMembers.Where(fm => fm.FamilyId == familyRecord.Id).Select(fm => fm.UserId).ToArray();
            var familyEventIds = _context.FamilyEvents.Where(fe => fe.FamilyId == familyRecord.Id).Select(e => e.Id).ToArray();
            var familyListIds = _context.FamilyLists.Where(fl => fl.FamilyId == familyRecord.Id).Select(l => l.Id).ToArray();
            return new Family
            {
                Id = familyRecord.Id,
                Name = familyRecord.Name,
                FamilyMemberIds = familyMemberIds,
                FamilyEventIds = familyEventIds,
                FamilyListIds = familyListIds
            };
        }

        public IEnumerable<Family> GetMany(IEnumerable<Guid> ids)
        {
            var families = new List<Family>();
            foreach (var id in ids)
            {
                var family = GetById(id);
                if (family is not null) families.Add(family);
            }

            return families;
        }

        public bool Update(Family entity)
        {
            var existingFamilyRecord = _context.Families.FirstOrDefault(f => f.Id == entity.Id);
            if (existingFamilyRecord is null)
            {
                Add(entity);
                return true;
            }

            if (existingFamilyRecord.Name != entity.Name)
            {
                existingFamilyRecord.Name = entity.Name;
                _context.Families.Update(existingFamilyRecord);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateMany(IEnumerable<Family> entities)
        {
            var familyIds = entities.Select(e => e.Id).ToHashSet();
            var existingFamilies = _context.Families.Where(f => familyIds.Contains(f.Id));
            var contextChanged = false;
            foreach (var existingFamily in existingFamilies)
            {
                var incomingFamily = entities.First(e => e.Id == existingFamily.Id);
                if (incomingFamily.Name != existingFamily.Name)
                {
                    existingFamily.Name = incomingFamily.Name;
                    _context.Families.Update(existingFamily);
                    contextChanged = true;
                }
            }

            if (contextChanged)
            {
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
