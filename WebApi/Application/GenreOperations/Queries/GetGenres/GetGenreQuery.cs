using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenreQuery
    {
        public readonly IBookStoreDbContext _context ;
        public readonly  IMapper _mapper ;
        public GetGenreQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x=> x.IsActive).OrderBy(X => X.id);
            List<GenresViewModel> returnobj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnobj;
        }
    }
    public class GenresViewModel
    {
        public int id { get; set; }
        public string Name {get; set;}
    }
}