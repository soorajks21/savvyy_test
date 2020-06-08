using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Test.Models;

namespace WebApi_Test.Data
{
    public interface IBookRespository
    {
        IEnumerable<Book> GetAllBooks();

        Book AddBook(Book book);
        Book GetBookByTitle(string title);

        Book UpdateBook(Book book);

        Book Delete(string title);


    }
}
