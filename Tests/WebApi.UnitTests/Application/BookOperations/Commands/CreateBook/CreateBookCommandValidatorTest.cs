
using FluentAssertions;
using TestSetup;
using Webapi.Application.BookOperations.Commands.CreateBook;
using Xunit;
using static Webapi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace Application.BookOperation.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
      
        [Theory]
        [InlineData("Lord of the rings",0,0,0)]
        [InlineData("Lord of the rings",0,0,1)]
        [InlineData("",0,0,0)]
        [InlineData("az",0,0,0)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title , int pageCount, int genreId, int authorId)
        {
            CreateBookCommand command = new CreateBookCommand(null ,null);
            command.Model = new CreateBookModel(){
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId= genreId,
                AuthorId= authorId
            };
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result =  validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null ,null);
        
            command.Model = new CreateBookModel(){
                Title = "Lord of the rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date,
                GenreId= 1,
                AuthorId= 1
            };
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result =  validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
            [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateBookCommand command = new CreateBookCommand(null ,null);
        
            command.Model = new CreateBookModel(){
                Title = "Lord of the rings",
                PageCount = 100,
                PublishDate = DateTime.Now.Date.AddYears(-2),
                GenreId= 1,
                AuthorId= 1
            };
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result =  validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
      
        
    }

}