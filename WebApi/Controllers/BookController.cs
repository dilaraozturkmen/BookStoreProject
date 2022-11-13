using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Webapi.BookOperations.CreateBook;
using Webapi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.CreateBook;
using WebApi.DBOperations;
using WebApi.DeleteBook;
using WebApi.UpdateBook;
using static Webapi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;


namespace WebApi.AddControllers{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context ,_mapper);
            var result = query.Handle();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context , _mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);
                result = query.Handle();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 

            }
            return Ok(result);

        }
      
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
             CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try{
                
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                ValidationResult result =  validator.Validate(command); 
                validator.ValidateAndThrow(command);
                command.Handle();
                // if(!result.IsValid ){
                //     foreach(var item in result.Errors){
                //         Console.WriteLine("Özellik " + item.PropertyName + "- Error Message: " +  item.ErrorMessage);
                //     }
                // }
                // else
                //     command.Handle();

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
                UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
                command.BookId = id;
                command.Model = uptadedBook;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                ValidationResult result =  validator.Validate(command); 
                validator.ValidateAndThrow(command);
                
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
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
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
