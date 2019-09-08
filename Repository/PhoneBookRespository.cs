using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Models;

namespace Repository
{
    public class PhoneBookRepository: RepositoryBase<PhoneBook>, IPhoneBookRepository
    {
        public PhoneBookRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }

        public IEnumerable<PhoneBook> GetAllPhoneBooks()
        {
            return FindAll()
                .OrderBy(pb => pb.Name)
                .ToList();
        }

        public PhoneBook GetPhoneBookById(Guid phoneBookId)
        {
            return FindByCondition(phoneBook => phoneBook.PhoneBookId.Equals(phoneBookId))
                    .DefaultIfEmpty(new PhoneBook())
                    .FirstOrDefault();
        }

        public PhoneBookExtended GetPhoneBookWithEntries(Guid phoneBookId)
        {
            return new PhoneBookExtended(GetPhoneBookById(phoneBookId))
            {
                Entries = RepositoryContext.Entries
                    .Where(a => a.PhoneBookId == phoneBookId)
            };
        }

        public void CreatePhoneBook(PhoneBook phoneBook)
        {
            phoneBook.PhoneBookId = Guid.NewGuid();
            Create(phoneBook);
        }
    }
}
