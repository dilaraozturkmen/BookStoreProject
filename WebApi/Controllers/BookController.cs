using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webapi.BookOperations.CreateBook;
using Webapi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static Webapi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.AddControllers{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context =context;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok(result);

        }
        //  [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book = BookList.Where(book =>book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;

        // }
        //post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
             CreateBookCommand command = new CreateBookCommand(_context);
            try{
                
                command.Model = newBook;
                command.Handle();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
           return Ok();
           
        }         

         
        
        //put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel uptadedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = uptadedBook;
                command.Handle();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
     
            return Ok();
          


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook (int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
       
            return Ok();

        }  
    }
}    
