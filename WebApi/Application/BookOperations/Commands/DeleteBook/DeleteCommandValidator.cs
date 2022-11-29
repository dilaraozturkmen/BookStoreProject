using FluentValidation;
using Webapi.Application.BookOperations.Commands.DeleteBook;

namespace  Webapi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(Command => Command.BookId).GreaterThan(0);
        }

    }
    
}