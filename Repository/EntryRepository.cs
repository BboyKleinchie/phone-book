using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class EntryRepository: RepositoryBase<Entry>, IEntryRepository
    {
        public EntryRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }

        public IEnumerable<Entry> GetAllEntries()
        {
            return FindAll()
                .OrderBy(e => e.Name)
                .ToList();
        }

        public Entry GetEntryById(Guid entryId)
        {
            return FindByCondition(entry => entry.EntryId.Equals(entryId))
                    .DefaultIfEmpty(new Entry())
                    .FirstOrDefault();
        }

        public void CreateEntry(Entry entry)
        {
            entry.EntryId = Guid.NewGuid();
            Create(entry);
        }
    }
}
