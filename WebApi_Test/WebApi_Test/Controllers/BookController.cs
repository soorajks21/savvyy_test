using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi_Test.Data;
using WebApi_Test.Models;
using WebApi_Test.ViewModels;

namespace WebApi_Test.Controllers
{


    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private IBookRespository _repository;

        public BookController(IBookRespository respository, IConfiguration config)
        {
            _repository = respository;

        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var bookItems = _repository.GetAllBooks();

            return Ok(bookItems);

        }

        [Authorize]
        [HttpPost("{title}")]
        public ActionResult<Book> AddBook([FromForm]BookViewModel book)
        {
            string uniqueName = ProcessUploadFiles(book);

            Book book1 = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                user = book.user,
                Image = uniqueName

            };

            var bookItem = _repository.AddBook(book1);


            return Ok(bookItem);
        }


        //[Authorize]
        //[HttpPost("{title}")]
        //public ActionResult<Book> AddBook([FromForm]Book book)
        //{
        //    var bookItem = _repository.AddBook(book);
        //    return Ok(bookItem);
        //}


        [Authorize]
        [HttpGet("{title}")]
        public ActionResult<Book> GetBookByTitle(string title)
        {
            var bookItem = _repository.GetBookByTitle(title);
            return Ok(bookItem);

        }
        [Authorize]
        [HttpDelete("{title}")]
        public ActionResult<Book> DeleteBookByTitle(string title)
        {
            var bookItem = _repository.Delete(title);
            return Ok(bookItem);
        }


        [Authorize]
        [HttpPut("{title}")]
        public ActionResult<Book> UpdateBook([FromForm]BookViewModel book)
        {
            Book bookItem = _repository.GetBookByTitle(book.Title);
            if(bookItem != null)
            {
                bookItem.Title = book.Title;
                bookItem.Description = book.Description;
                bookItem.Price = book.Price;
                bookItem.user = book.user;
            }
            if(book.Photos != null)
            {
                try
                {
                    string filePath = Path.Combine("Resources/images", bookItem.Image);
                    System.IO.File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("no images");
                }
            }
            string uniqueFilename = ProcessUploadFiles(book);
            bookItem.Image = uniqueFilename;

            //  var bookItem = _repository.UpdateBook(book);
            return Ok(bookItem);
        }


        private string ProcessUploadFiles(BookViewModel model)
        {
            string uniqueFilename = null;
            if (model.Photos != null)
            {

                //string uploadsFolder = Path.Combine("Resources", "image");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + model.Photos.FileName;
                string filePath = Path.Combine("Resources/images", uniqueFilename);
                model.Photos.CopyTo(new FileStream(filePath, FileMode.Create));


            }

            return uniqueFilename;
        }

    }
}
