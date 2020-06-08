using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Test.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Description{ get; set; }
      
        public string Image { get; set; }
        public double Price { get; set; }

        public User user { get; set; }
    }
}
