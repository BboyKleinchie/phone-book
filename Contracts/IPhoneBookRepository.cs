using System;
using System.Collections.Generic;
using System.Text;
using Entities.ExtendedModels;
using Entities.Models;

namespace Contracts
{
    public interface IPhoneBookRepository : IRepositoryBase<PhoneBook>
    {
        IEnumerable<PhoneBook> GetAllPhoneBooks();
        PhoneBook GetPhoneBookById(Guid phoneBookId);
        PhoneBookExtended GetPhoneBookWithEntries(Guid phoneBookId);
        void CreatePhoneBook(PhoneBook phoneBook);
    }
}
