using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdWeekHomework.Domain.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
