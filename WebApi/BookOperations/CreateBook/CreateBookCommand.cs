using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi;

namespace Webapi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}
        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(X=>X.Title == Model.Title);
            if(book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut");
            book = new Book();
            book .PageCount = Model.PageCount;
            book.PublishDate =Model.PublishDate;
            book.GenreId = Model.GenreId;
            book.Title = Model.Title;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
           

        }
        public class CreateBookModel
        {
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        }
    }

}