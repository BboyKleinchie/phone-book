using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("entry")]
    public class Entry
    {
        [Key]
        public Guid EntryId { get; set; }

        [Required(ErrorMessage = "Name of phone book entry is required")]
        [StringLength(60, ErrorMessage = "Name cannot be more than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, ErrorMessage = "Phone number cannot be more than 10 numbers")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Phone Book Id is required")]
        public Guid PhoneBookId { get; set; }
    }
}
