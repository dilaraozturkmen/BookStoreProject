using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
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
        
            // book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            // // book.PageCount = uptadedBook.PageCount != default ? Model.PageCount : book.PageCount;
            // // book.PublishDate = uptadedBook.PublishDate != default ? uptadedBook.PublishDate : book.PublishDate;
            // book.Title = Model.Title != default ? Model.Title : book.Title;
          
            _dbContext.SaveChanges();

          
        }
        public class UpdateBookModel
        {
        
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
   
        }
    }
}