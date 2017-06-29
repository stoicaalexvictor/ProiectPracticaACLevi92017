using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services
{
    public class LibraryServicescs : ILibraryService
    {
        
        public IList<Book> GetBooks()
        {

            return _context.Books.ToList();

            /*return new List<Book>()
            {
                new Book(){Id=1,Name="Name #1", Author="Author #1" },
                new Book(){Id=2,Name="Name #3", Author="Author #2" },
                new Book(){Id=3,Name="Name #2", Author="Author #3" }
            };*/
        }

        private ApplicationDbContext _context;



        public LibraryServicescs(ApplicationDbContext context)
        {
            _context = context;
        }


        public IList<Transaction> GetAllTransactions()
        {
            return _context.Transaction.Include(item => item.User).ToList();
        }

        public bool Borrow(string userId, int id)
        {
            _context.Transaction.Add(new Transaction
            {
                UserId = userId,
                BookId = id
            });
            return _context.SaveChanges() == 1;
        }
    }
}
