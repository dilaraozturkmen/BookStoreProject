using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Webapi.Application.BookOperations.Commands.CreateBook;
using Webapi.Application.BookOperations.Commands.DeleteBook;
using Webapi.Application.BookOperations.Commands.UpdateBook;
using WebApi.Application.Queries.BookOperations.GetBookDetail;
using WebApi.Application.Queries.BookOperations.GetBooks;
using WebApi.DBOperations;
using static Webapi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static Webapi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using static WebApi.Application.Queries.BookOperations.GetBookDetail.GetBookDetailQuery;

namespace WebApi.AddControllers{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(IBookStoreDbContext context, IMapper mapper)
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
        
            GetBookDetailQuery query = new GetBookDetailQuery(_context , _mapper);
            query.BookId = id;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

        
        
            return Ok(result);

        }
      
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        
            command.Model = newBook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            ValidationResult result =  validator.Validate(command); 
            validator.ValidateAndThrow(command);
            command.Handle();
             
           return Ok();
           
        }         

         
        
        //put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel uptadedBook)
        {
           
            UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);
            command.BookId = id;
            command.Model = uptadedBook;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            ValidationResult result =  validator.Validate(command); 
            validator.ValidateAndThrow(command);
            
            command.Handle();
     
            return Ok();
          


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook (int id)
        {
           
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }  
    }
}    
