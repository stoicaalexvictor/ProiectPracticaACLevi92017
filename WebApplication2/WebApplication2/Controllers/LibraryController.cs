using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using WebApplication2.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WebApplication2.Models.LibraryViewModels;

namespace WebApplication2.Controllers
{

    [Authorize]
    public class LibraryController : Controller
    {
        private ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public IActionResult Index()
        {


            var books = _libraryService.GetBooks();

            var transaction = _libraryService.GetAllTransactions();

            var model = new LibraryViewModel(books);
            

            return View(model);
        }

        public IActionResult Borrow(int id)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isSuccessful = _libraryService.Borrow(userId, id);

            var book = _libraryService.GetBooks().Single(item => item.Id == id);

            var borrowViewModel = new BorrowViewModel
            {
                IsSuccessful = isSuccessful,
                BookName = book.Name
            };

            return View(borrowViewModel);
        }
    }
}