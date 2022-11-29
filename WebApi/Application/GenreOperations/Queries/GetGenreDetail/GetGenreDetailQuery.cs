using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context ;
        public readonly  IMapper _mapper ;
        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.IsActive && x.id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("Kitap Türü bulanamadı");
          
            GenreDetailViewModel vm =_mapper.Map<GenreDetailViewModel>(genre);
            return vm;
        }
    }
    public class GenreDetailViewModel
    {
        public int id { get; set; }
        public string Name {get; set;}
        
    }
}