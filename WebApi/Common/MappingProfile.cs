using AutoMapper;
using WebApi.BookOperations.GetBooks;
using static Webapi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             CreateMap<CreateBookModel , Book>();
             CreateMap<Book , BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
             CreateMap<Book , BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
             CreateMap<UpdateBookModel , Book>();

        }

    }
       


    
}