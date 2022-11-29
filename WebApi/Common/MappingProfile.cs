using AutoMapper;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.Queries.BookOperations.GetBooks;
using WebApi.Entities;
using static Webapi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static Webapi.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using static WebApi.Application.Queries.BookOperations.GetBookDetail.GetBookDetailQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             CreateMap<CreateBookModel , Book>();
             CreateMap<Book , BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>src.Genre.Name));
             CreateMap<Book , BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>src.Genre.Name.ToString()));
             CreateMap<UpdateBookModel , Book>();
             CreateMap<Genre, GenresViewModel>();
             CreateMap<Genre, GenreDetailViewModel>();

        }

    }
       


    
}