﻿using harmonee.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace harmonee.Server.Data
{
    public class FamilyListRepository : IFamilyListRepository
    {
        private readonly FamilyListContext _context;

        public FamilyListRepository(FamilyListContext context)
        {
            _context = context;
        }

        public bool Add(FamilyList entity)
        {
            var existingList = _context.FamilyLists.FirstOrDefault(fl => fl.Id == entity.Id);
            if (existingList is not null)
            {
                return false;
            }

            _context.FamilyLists.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool AddMany(IEnumerable<FamilyList> entities)
        {
            var contextChanged = false;
            var incomingIds = entities.Select(fl => fl.Id).ToHashSet();
            var existingFamilyListIds = _context.FamilyLists.Where(fl => incomingIds.Contains(fl.Id)).Select(fl => fl.Id).ToHashSet();
            var listsToAdd = entities.Where(fl => !existingFamilyListIds.Contains(fl.Id));

            foreach (var listToAdd in listsToAdd)
            {
                _context.Add(listToAdd);
                contextChanged = true;
            }

            if (contextChanged)
            {
                _context.SaveChanges();
            }

            return contextChanged;
        }

        public bool Delete(Guid id)
        {
            var existingFamilyList = _context.FamilyLists.FirstOrDefault(fl => fl.Id == id);
            if (existingFamilyList is not null)
            {
                _context.FamilyLists.Remove(GetById(id));
                _context.SaveChanges();
                return true;    
            }

            return false;
        }

        public bool DeleteMany(IEnumerable<Guid> ids)
        {
            var familiesToRemove = _context.FamilyLists.Where(f => ids.Contains(f.Id));
            if (familiesToRemove.Count() == 0)
            {
                return false;
            }

            _context.FamilyLists.RemoveRange(familiesToRemove);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<FamilyList> GetAll()
        {
            return _context.FamilyLists.ToList();
        }

        public FamilyList? GetById(Guid id)
        {
            return _context.FamilyLists.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<FamilyList> GetMany(IEnumerable<Guid> ids)
        {
            return _context.FamilyLists.Where(f => ids.Contains(f.Id));
        }

        public bool Update(FamilyList entity)
        {
            var existingList = _context.FamilyLists.FirstOrDefault(fl => fl.Id == entity.Id);
            if (existingList is null)
            {
                return false;
            }
            
            if (entity.Equals(existingList))
            {
                return false;
            }

            _context.FamilyLists.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateMany(IEnumerable<FamilyList> entities)
        {
            var contextChanged = false;
            var incomingListIds = entities.Select(fl => fl.Id).ToHashSet();
            var existingRecords = _context.FamilyLists.Where(fl => incomingListIds.Contains(fl.Id));
            foreach (var existingRecord in existingRecords)
            {
                var incomingRecord = entities.FirstOrDefault(fl => fl.Id == existingRecord.Id);
                if (!incomingRecord.Equals(existingRecord))
                {
                    _context.Update(incomingRecord);
                    contextChanged = true;
                }
            }

            if (contextChanged)
            {
                _context.SaveChanges();
            }

            return contextChanged;
        }
    }

    public class FamilyListContext : DbContext
    {
        public DbSet<FamilyList> FamilyLists { get; set; }
        private readonly string _connectionString;

        public FamilyListContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use appropriate server and connection string
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
