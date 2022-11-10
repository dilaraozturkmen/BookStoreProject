using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

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
        public List<Book> GetBooks()
        {
            var bookList = _context.Books.OrderBy(x=> x.Id).ToList<Book>();
            return bookList;

        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;

        }
        //  [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book = BookList.Where(book =>book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;

        // }
        //post
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook){
            var book = _context.Books.SingleOrDefault(X=>X.Title == newBook.Title);
            if(book is not null)
                return BadRequest();

            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
        }         

         
        
        //put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] Book uptadedBook)
        {
            var book = _context.Books.SingleOrDefault(X=>X.Id == id);
            if(book is null)
                return BadRequest();
            book.GenreId = uptadedBook.GenreId != default ? uptadedBook.GenreId : book.GenreId;
            book.PageCount = uptadedBook.PageCount != default ? uptadedBook.PageCount : book.PageCount;
            book.PublishDate = uptadedBook.PublishDate != default ? uptadedBook.PublishDate : book.PublishDate;
            book.Title = uptadedBook.Title != default ? uptadedBook.Title : book.Title;
          
            _context.SaveChanges();

            return Ok();


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook (int id)
        {
            var book = _context.Books.SingleOrDefault(X=>X.Id == id);
            if(book is null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();

        }  
    }
}    
