using ASPNetCoreWebAPI.Data;
using ASPNetCoreWebAPI.Entities;
using ASPNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookData _bookService;
        public BookController(IBookData bookService)
        {
            _bookService = bookService;
        }


        [HttpGet("get-books")]
        public IActionResult GetBooks()
        {
            try
            {
                var books = _bookService.ListBooks().Select(b => new BookModel
                {
                    Author = b.Author,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    Publisher = b.Publisher,
                    Title = b.Title
                });
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            //return BadRequest("Victor");
            //return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure!");
        }


        [HttpGet("get-books-async")]
        public async Task<IActionResult> GetBooksAsync()
        {
            try
            {
                var books = await _bookService.ListBooksAsync();
                var bookModels = books.Select(b => new BookModel
                {
                    Author = b.Author,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    Publisher = b.Publisher,
                    Title = b.Title
                });
                return Ok(bookModels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            //return BadRequest("Victor");
            //return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure!");
        }

        [HttpGet("get-book-by-id/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var result = await _bookService.GetBookAsync(id);
                if (result == null)
                {
                    return NotFound($"The Book with Id {id}, was not found.");
                }
                return Ok(new BookModel
                {
                    Author = result.Author,
                    Description = result.Description,
                    ISBN = result.ISBN,
                    Publisher = result.Publisher,
                    Title = result.Title
                });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookModel model)
        {

            try
            {
                var book = new Book
                {
                    Author = model.Author,
                    Description = model.Description,
                    ISBN = model.ISBN,
                    Publisher = model.Publisher,
                    Title = model.Title
                };

                _bookService.AddBook(book);
                var result = _bookService.Save();
                if (result > 0)
                {
                    return Ok("Book was saved successfully!");
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("update-book/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookModel model)
        {
            try
            {
                var bookToUpdate = await _bookService.GetBookAsync(id);
                if (bookToUpdate != null)
                {
                    bookToUpdate.Title = model.Title;
                    bookToUpdate.Description = model.Description;
                    bookToUpdate.Publisher = model.Publisher;
                    bookToUpdate.ISBN = model.ISBN;
                    bookToUpdate.Author = model.Author;
                }

                else
                {
                    return NotFound($"Book with Id, {id} was not found");
                }


                _bookService.UpdateBook(bookToUpdate);
                var result = _bookService.Save();
                if (result > 0)
                {
                    return Ok("Book was updated successfully!");
                }



                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("delete-book/{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            try
            {
                var bookToDelete = await _bookService.GetBookAsync(id);
                if (bookToDelete == null)
                {
                    return NotFound($"Book with Id, {id} cannot be found!");
                }

                var result = await _bookService.DeleteAsync<Book>(bookToDelete);
                if (result == true)
                {
                    return Ok("Book successfully deleted!");
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
     
        
        }

        [HttpGet("search-books/{keyword}")]
        public IActionResult SearchBooks([FromRoute] string keyword)
        {
            try
            {
                var books = _bookService.Search(keyword);
                return Ok(books);
            }

            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
