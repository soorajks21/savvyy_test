using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Test.Models;

namespace WebApi_Test.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

      
        public double Price { get; set; }

        public User user { get; set; }

        public IFormFile Photos { get; set; }
    }
}
