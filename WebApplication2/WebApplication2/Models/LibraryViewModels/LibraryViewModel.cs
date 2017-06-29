using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Entities;

namespace WebApplication2.Models
{
    public class LibraryViewModel
    {
        public int NumberOfBooks { get; set; }
        public DateTime Data { get; set; }

        //metoda mea
        /*public int[] BookNumber { get; set; } = new int[5];
        public string []Author { get; set; } = new string[5];
        public string []BookName { get; set; } = new string[5];
        */


        //metoda Levi9
        public IList<BookViewModel> Books { get; set; }

        public LibraryViewModel(IList<Book> books)
        {
            Books = new List<BookViewModel>();

            foreach(var book in books)
            {
                var bookViewModel = new BookViewModel()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author
                };

                Books.Add(bookViewModel);
            }
        }

    }
}
