using BookLib;
using System;
using System.Collections.Generic;
using WebApi_Test.Models;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
       
        
            
        [Fact]
        public void Test_invalid_Title()
        {
            var test = new Test();
            
            Book books = new Book();
            User user = new User();
            user.Name = "sooraj";
            books.Title = null;
            books.Price = 50;
            books.Description = "motivation";
            books.user = user;

            Console.WriteLine(books);

            Assert.Throws<ArgumentOutOfRangeException>(() => test.AddBook(books));
        }

        [Fact]
        public void Test_invalid_Price()
        {
          
            var test = new Test();
            User user = new User();
            user.Name = "sooraj";
            Book books = new Book();
            books.Title = "the power";
            books.Price = 0;
            books.Description = "motivation";
            books.user = user;


            Assert.Throws<ArgumentOutOfRangeException>(() => test.AddBook(books));
        }


        [Fact]
        public void Test_invalid_Description()
        {
            var test = new Test();
            User user = new User();
            user.Name = "sooraj";
            Book books = new Book();
            books.Title = "the power";
            books.Price = 50;
            books.Description = " ";
            books.user = user;


            Assert.Throws<ArgumentOutOfRangeException>(() => test.AddBook(books));
        }

        [Fact]
        public void Test_invalid_User()
        {
            var test = new Test();
            User user = new User();
            user.Name = null;
            Book books = new Book();
            books.Title = "the power";
            books.Price = 50;
            books.Description = "the power";
            books.user = user;


            Assert.Throws<ArgumentOutOfRangeException>(() => test.AddBook(books));
        }

        [Fact]
        public void Test_valid_User()
        {
            var test = new Test();
            User user = new User();
            user.Name = "sooraj";
            Book books = new Book();
            books.Title = "the power";
            books.Price = 5;
            books.Description = "the power";
            books.user = user;


            Assert.Throws<ArgumentOutOfRangeException>(() => test.AddBook(books));
        }

    }
}
