using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<Entry> Entries { get; set; }
    }
}
