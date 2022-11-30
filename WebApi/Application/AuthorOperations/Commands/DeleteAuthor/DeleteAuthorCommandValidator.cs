using FluentValidation;
using Webapi.Application.DeleteAuthor;

namespace  Webapi.Application.BookOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(Command => Command.AuthorId).GreaterThan(0);
        }

    }
    
}