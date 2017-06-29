using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BookId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Book Book { get; set; }

    }
}
