using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdWeekHomework.Data.DTOs
{
    public class BookDTO 
    {
        public int? Id { get; set; }
        public string BookName { get; set; }
        public int? PageNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }         
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string AuthorName { get; set; }
    }
}
