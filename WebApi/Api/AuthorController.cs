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
        protected AuthorController()
        {
        }

        [HttpGet, Route("Api/GetAllAuthors")]
        public List<Author> GetAll()
        {
            kokoEntities dbcontext = new kokoEntities();

            return dbcontext.Author.ToList();
        }

        [HttpPost, Route("Api/AddAutho")]
        public void AddAuthor(Author newAuthor)
        {
            kokoEntities dbcontext = new kokoEntities();

            dbcontext.Author.Add(newAuthor);
            dbcontext.SaveChanges();

        }

    }
}
