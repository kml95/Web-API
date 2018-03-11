using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Api
{
    public class AuthorController : ApiController
    {
        private readonly kokoEntities dbcontext;

        public AuthorController(kokoEntities dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet, Route("Api/GetAllAuthors")]
        public IEnumerable<Author> GetAll()
        {
            return dbcontext.Author.ToList();
        }

        [HttpPost, Route("Api/AddAuthor")]
        public void AddAuthor(Author newAuthor)
        {
            dbcontext.Author.Add(newAuthor);
            dbcontext.SaveChanges();
        }

    }
}
