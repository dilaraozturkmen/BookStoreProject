using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.CreateBook
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model {get; set;}
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public CreateGenreCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre is not null)
                throw new InvalidOperationException("Kitap türü zaten mevcut");
            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();

        }


    }
    public class CreateGenreModel
    {
        public string Name {get; set;}
    }
}