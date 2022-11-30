using FluentValidation;
using WebApi.Application.AuthorOperations.GetAuthorDetail;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailOueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailOueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
    }
}