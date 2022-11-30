using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.Common;
using WebApi.DBOperations;

namespace Webapi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
  
        public  int BookId {get; set;}
        public UpdateBookModel Model {get; set;}
        public UpdateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle(){
             Book book = _dbContext.Books.SingleOrDefault(X=>X.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("Kitap Bulanamadı");
           _mapper.Map(Model,book);
          
            _dbContext.SaveChanges();

          
        }
        public class UpdateBookModel
        {
        
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
   
        }
    }
}