using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("phonebook")]
    public class PhoneBook
    {
        [Key]
        public Guid PhoneBookId { get; set; }

        [Required(ErrorMessage = "Name of phone book is required")]
        [StringLength(45, ErrorMessage = "Name cannot be more than 45 characters")]
        public string Name { get; set; }
    }
}
