using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.UpdateBook
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model  { get; set; }
        public readonly BookStoreDbContext _context;

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.id == GenreId);
            if(genre is null)
                throw new InvalidOperationException("Kitap türü bulanamadı");
            if(_context.Genres.Any(x=> x.Name == Model.Name.ToLower() && x.id != GenreId))
                throw new InvalidOperationException("Aynı isimli bir kitap zaten mevcut");
            genre.Name = Model.Name.Trim() == default ? Model.Name : genre.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();

        }

    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}