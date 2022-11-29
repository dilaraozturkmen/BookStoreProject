using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi;

namespace Webapi.Application.BookOperations.Commands.DeleteBook
{
     public class DeleteBookCommand
     {
        private readonly BookStoreDbContext _dbContext;
        public int BookId {get; set;}
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(X=>X.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("Kitap Bulanamadı");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            
        }
    }
}

