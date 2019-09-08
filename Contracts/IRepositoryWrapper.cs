using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IPhoneBookRepository PhoneBook { get; }
        IEntryRepository Entry { get; }
        void Save();
    }
}
