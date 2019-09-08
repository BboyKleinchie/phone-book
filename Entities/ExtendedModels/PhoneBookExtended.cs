using Entities;
using Entities.Models;
using System;
using System.Text;
using System.Collections.Generic;

namespace Entities.ExtendedModels
{
    public class PhoneBookExtended
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Entry> Entries { get; set; }

        public PhoneBookExtended()
        {

        }

        public PhoneBookExtended(PhoneBook phoneBook)
        {
            Id = phoneBook.PhoneBookId;
            Name = phoneBook.Name;
        }
    }
}
