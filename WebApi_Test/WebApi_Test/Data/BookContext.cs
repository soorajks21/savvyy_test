using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Test.Models;

namespace WebApi_Test.Data
{
    public class BookContext : DbContext
    {

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public DbSet<Book> books { get; set; }
        public DbSet<User> users { get; set; }

    }
}
