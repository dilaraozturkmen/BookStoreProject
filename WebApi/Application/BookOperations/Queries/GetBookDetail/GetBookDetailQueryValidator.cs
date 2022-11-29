using FluentValidation;

namespace WebApi.Application.Queries.BookOperations.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
             RuleFor(Query => Query.BookId).GreaterThan(0);

        }
    }
    
}