using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace Webapi.Application.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId;
        public readonly BookStoreDbContext _context;
      
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
            
        }
        public void Handle()
        {
            var authorBooks = _context.Books.Include( x=> x.Author).SingleOrDefault(x=>x.AuthorId == AuthorId);
            if(authorBooks is not null)
                throw new InvalidOperationException("Bu yazara ait kitap buluduğu için kayıt silinemedi.");

            var author = _context.Authors.SingleOrDefault(X=>X.id == AuthorId);
             if(author is null)
                throw new InvalidOperationException("Yazar Bulanamadı");
            _context.Authors.Remove(author);
            _context.SaveChanges();

        }
    }
}