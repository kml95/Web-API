using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DTO;
using WebApi.Models;

namespace WebApi.Api
{
    public class AuthorController : ApiController
    {
        private readonly kokoEntities dbContext;

        public AuthorController(kokoEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet, Route("Api/GetAllAuthors")]
        public IEnumerable<AuthorDTO> GetAll()
        {
            var authors = dbContext.Author.ToList();

            List<AuthorDTO> authorsDTO = new List<AuthorDTO>();
            foreach (var author in authors)
            {
                authorsDTO.Add(new AuthorDTO
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    Age = author.Age ?? 0,
                    City = author.City,
                    LastName = author.LastName
                });
            }

            return authorsDTO;
        }

        [HttpPost, Route("Api/AddAuthor")]
        public IHttpActionResult AddAuthor(Author newAuthor)
        {
            if (newAuthor != null)
            {
                dbContext.Author.Add(newAuthor);
                dbContext.SaveChanges();
            }

            return Ok();
        }

        [HttpPut, Route("Api/EditAuthor")]
        public IHttpActionResult EditAuthor(Author editedAuthor)
        {
            if (editedAuthor != null)
            {
                dbContext.Entry(editedAuthor).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete, Route("Api/DeleteAuthor/{id}")]
        public IHttpActionResult DeleteAuthor([FromUri] int id)
        {
            Author author = dbContext.Author.Find(id);
            dbContext.Author.Remove(author);
            dbContext.SaveChanges();

            return Ok();
        }

    }
}
