using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class AddBookDTO
    {
        public string Title { get; set; }
        public string AuthorLastName { get; set; }
        public int Year { get; set; }
    }
}