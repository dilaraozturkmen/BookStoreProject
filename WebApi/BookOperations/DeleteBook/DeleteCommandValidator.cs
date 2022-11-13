using FluentValidation;
using Webapi.BookOperations.DeleteBook;

namespace  WebApi.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(Command => Command.BookId).GreaterThan(0);
        }

    }
    
}