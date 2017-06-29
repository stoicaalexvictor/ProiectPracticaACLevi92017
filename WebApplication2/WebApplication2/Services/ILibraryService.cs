using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Entities;

namespace WebApplication2.Services
{
    public interface ILibraryService
    {
        IList<Book> GetBooks();
        IList<Transaction> GetAllTransactions();
        bool Borrow(string userId, int id);
    }
}
