using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailOueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailOueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}