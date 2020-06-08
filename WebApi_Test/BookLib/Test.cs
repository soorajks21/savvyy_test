using System;
using System.Collections.Generic;
using System.Text;
using WebApi_Test.Models;

namespace BookLib
{
  public  class Test : IBook_Test
    {
        public void AddBook(Book Book)
        {
        
            if (Book.Title == null)
            {
                throw new ArgumentException("Must add a title");
            }

            if(Book.user.Name  == null)
            {
                throw new ArgumentException("Must add user name");

            }

            if (Book.Description.Equals(" "))
            {
                throw new ArgumentException("Must add book description");

            }

            if (Book.Price == 0)
            {
                throw new ArgumentException("Must add price");

            }


        }
    }
}
