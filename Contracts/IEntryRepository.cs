using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IEntryRepository: IRepositoryBase<Entry>
    {
        IEnumerable<Entry> GetAllEntries();
        Entry GetEntryById(Guid entryId);
        void CreateEntry(Entry entry);
    }
}
