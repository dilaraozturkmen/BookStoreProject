using AutoMapper;
using WebApi.Application.AuthorOperations.GetAuthorDetail;
using WebApi.Application.CreateAuthor;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GetAuthors;
using WebApi.Application.Queries.BookOperations.GetBooks;
using WebApi.Application.UpdateAuthor;
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
             CreateMap<Book , BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>src.Genre.Name)).ForMember(dest => dest.Author , opt =>opt.MapFrom(src => src.Author.Name.ToString() + " "+ src.Author.Surname.ToString()));
             CreateMap<Book , BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>src.Genre.Name.ToString())).ForMember(dest => dest.Author , opt =>opt.MapFrom(src => src.Author.Name.ToString() + " "+ src.Author.Surname.ToString()));
             CreateMap<UpdateBookModel , Book>();
             CreateMap<Genre, GenresViewModel>();
             CreateMap<Genre, GenreDetailViewModel>();
             CreateMap<CreateAuthorModel , Author>();
             CreateMap<Author , AuthorDetailViewModel>();
             CreateMap<Author , AuthorViewModel>();
             CreateMap<UpdateAuthorModel , Author>();

        }

    }
       


    
}