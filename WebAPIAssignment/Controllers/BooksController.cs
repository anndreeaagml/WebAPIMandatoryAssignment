using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookLibraryAssignemnt;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPIAssignment.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {


        private static List<Book> lBooks;

        public BooksController()
        {
            lBooks = BookModel.BookList;
        }


        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return lBooks;
        }

        // GET api/<BookController>/5
        [HttpGet("{isbn13}")]
        public IActionResult Get(string isbn13)
        {
            var book = BookModel.GetBook(isbn13);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound(new { message = "Isbn not Found!" });
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Book newBook)
        {

            if (!BookExists(newBook.Isbn))
            {
                lBooks.Add(newBook);
                return CreatedAtAction("Get", new { Isbn13 = newBook.Isbn }, newBook);
            }
            else
            {
                return NotFound(new { message = "Isbn13 is duplicate" });
            }

        }

        // PUT api/<BookController>/5
        [HttpPut("{Isbn13}")]
        public IActionResult Put(string Isbn13, [FromBody] Book updatedBook)
        {
            if (Isbn13 != updatedBook.Isbn)
            {
                return BadRequest();
            }

            Book currentBook = BookModel.GetBook(Isbn13);

            if (currentBook != null)
            {
                lBooks.Remove(currentBook);
                lBooks.Add(updatedBook);

            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{isbn13}")]
        public IActionResult Delete(string isbn13)
        {
            var book = BookModel.GetBook(isbn13);
            if (book != null)
            {
                lBooks.Remove(book);
            }
            else
            {
                return NotFound();
            }

            return Ok(book);
        }


        // Helper method

        private bool BookExists(string isbn13)
        {
            return lBooks.Any(b => b.Isbn == isbn13);
        }
    }
}
