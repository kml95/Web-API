using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Api
{
    public class BookController : ApiController
    {
        private readonly kokoEntities dbcontext;
        asdasd
        public BookController(kokoEntities dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet, Route("Api/GetAllBooks")]
        public IEnumerable<Book> GetAll()
        {
            kokoEntities dbcontext = new kokoEntities();

            return dbcontext.Book.ToList();

        }

        [HttpPost, Route("Api/AddBook")]
        public void AddBook(Book newBook)
        {
            kokoEntities dbcontext = new kokoEntities();

            dbcontext.Book.Add(newBook);
            dbcontext.SaveChanges();

        }
    }
}
