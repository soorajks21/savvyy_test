using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Test.Models;

namespace WebApi_Test.Data
{
    public class MockBookRepository : IBookRespository
    {
        List<Book> books;
        public MockBookRepository()
        {
             books = new List<Book>
            {
                new Book { Title = "the power", Description = "motivation", user = new User { Name = "sooraj" },  Price = 25 },
                new Book { Title = "the angry", Description = "motivation", user = new User { Name = "jerald" },  Price = 25 },
                 new Book { Title = "the cue", Description = "motivation", user = new User { Name = "vishnu" }, Price = 25 }

        };
        }

        public IEnumerable<Book> GetAllBooks()
        {
            

            return books;
        }

        public Book GetBookByTitle(string title)
        {
         
            return new Book { Title = "the power", Description = "motivation", user = new User { Name = "sooraj" },  Price = 25 };
        }

        public Book UpdateBook(Book in_book)
        {

            Book book = books.FirstOrDefault(e => e.Title == in_book.Title);
            if (book != null)
            {
                book.Title = in_book.Title;
                book.Image = in_book.Image;
                book.Price = in_book.Price;
                book.user.Name = in_book.user.Name;
                
            }
            return book;
        }

        public Book Delete(string title)
        {
            Book book = books.FirstOrDefault(e => e.Title == title);
            if(book != null)
            {
                books.Remove(book);
            }
            return book;
        }

        public Book AddBook(Book book)
        {
          var bk = books.Where(e => e.Title == book.Title);
            if(bk != null)
            {

                books.Add(book);
            }
            return book;
          
        }
    }
}
