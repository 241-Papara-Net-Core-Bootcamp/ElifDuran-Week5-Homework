using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdWeekHomework.Domain.Entities
{
    [Table("book")]
    public class Book : BaseEntity
    {
        public string  BookName { get; set; }
        public string  AuthorName { get; set; }
        public int?  PageNumber { get; set; }
        public DateTime?  PublishedDate { get; set; }
    }
}
