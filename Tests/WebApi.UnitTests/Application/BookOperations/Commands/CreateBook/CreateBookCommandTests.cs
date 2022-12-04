using AutoMapper;
using FluentAssertions;
using TestSetup;
using Webapi.Application.BookOperations.Commands.CreateBook;
using WebApi;
using WebApi.DBOperations;
using Xunit;
using static Webapi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace Application.BookOperation.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;

        }
        [Fact]
        public void WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn()
        {
            var book = new Book(){
                Title ="WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn",
                PageCount = 100,
                PublishDate= new DateTime(1990,01,10),
                GenreId=1,
                AuthorId= 1
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model = new CreateBookModel(){Title = book.Title};
            FluentActions 
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");


        }
        [Fact]
        public void WhenValidInpurAreGiven_Book_ShouldBeCreated()
        {
             CreateBookCommand command = new CreateBookCommand(_context,_mapper);
             CreateBookModel  model = new CreateBookModel(){Title = "Hobbit",PageCount=500,GenreId=1,AuthorId=1,PublishDate= DateTime.Now.Date.AddYears(-1)};
             command.Model = model;

             FluentActions.Invoking(()=> command.Handle()).Invoke();

             var book = _context.Books.SingleOrDefault(book=> book.Title == model.Title);
             book.Should().NotBeNull();
             book.PageCount.Should().Be(model.PageCount);
             book.GenreId.Should().Be(model.GenreId);
             book.AuthorId.Should().Be(model.AuthorId);


        }

        
    }

}