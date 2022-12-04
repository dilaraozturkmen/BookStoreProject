using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.DeleteBook
{
    public class DeleteGenreCommand
    {
        public int  GenreId { get; set; }
        private readonly IBookStoreDbContext _context;
        public DeleteGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.id == GenreId);
            if ( genre is null)
                throw new InvalidOperationException("Kitap türü bulanamadı");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }

}