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
    public class BookController : ApiController
    {
        private readonly kokoEntities dbContext;

        public BookController(kokoEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet, Route("Api/GetAllBooks")]
        public IEnumerable<BookDTO> GetAll()
        {
            var books = dbContext.Book.ToArray();

            List<BookDTO> booksDTO = new List<BookDTO>();
            foreach(var book in books)
            {
                booksDTO.Add(new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    AuthorId = book.AuthorId ?? 0,
                    Year = book.Year ?? 0
                });
            }
            return booksDTO;
        }

        [HttpPost, Route("Api/AddBook")]
        public IHttpActionResult AddBook([FromBody] AddBookDTO newBook)
        {
            if (newBook != null)
            {
                var authorId = getAuthorIdByLastName(newBook.AuthorLastName);
                Book b = new Book {
                    Id = dbContext.Book.OrderByDescending(a => a.Id).FirstOrDefault().Id + 1,
                    Title = newBook.Title,
                    AuthorId = authorId,
                    Year = newBook.Year
                };
                dbContext.Book.Add(b);
                dbContext.SaveChanges();
            }

            return Ok();
        }

        [HttpPut, Route("Api/EditBook")]
        public IHttpActionResult EditBook(Book editedBook)
        {
            if (editedBook != null)
            {
                dbContext.Entry(editedBook).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete, Route("Api/DeleteBook/{id}")]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = dbContext.Book.Find(id);
            dbContext.Book.Remove(book);
            dbContext.SaveChanges();

            return Ok();
        }

        public int getAuthorIdByLastName(string lastName)
        {
            Author author = dbContext.Author.Where(a => a.LastName == lastName).FirstOrDefault();
            return author.Id;
        }
    }
}