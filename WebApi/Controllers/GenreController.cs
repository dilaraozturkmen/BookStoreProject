using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.CreateBook;
using WebApi.Application.GenreOperations.DeleteBook;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenreQuery query = new GetGenreQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);

        }
        [HttpGet("id")]
        public ActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
            query.GenreId = id;
            GetGenreDetailOueryValidator validator = new GetGenreDetailOueryValidator();
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);

        }
        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context,_mapper);
            command.Model = newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id , [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, _mapper);
            command.GenreId = id;
            command.Model = updateGenre;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }



    }
    
}
