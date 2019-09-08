using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IPhoneBookRepository _phoneBook;
        private IEntryRepository _entry;
        
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IPhoneBookRepository PhoneBook
        {
            get
            {
                if (_phoneBook == null)
                {
                    _phoneBook = new PhoneBookRepository(_repositoryContext);
                }
                return _phoneBook;
            }
        }

        public IEntryRepository Entry
        {
            get
            {
                if (_entry == null)
                {
                    _entry = new EntryRepository(_repositoryContext);
                }
                return _entry;
            }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
