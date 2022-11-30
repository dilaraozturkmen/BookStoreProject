using FluentValidation;
using WebApi.Application.UpdateAuthor;

namespace Webapi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Surname).NotEmpty();
            RuleFor(command => command.Model.DateOfBirth.Date).NotEmpty().LessThan(DateTime.Now.Date);
            

        }

    }
}