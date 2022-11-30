using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        public readonly BookStoreDbContext _context ;
        public readonly  IMapper _mapper ;
        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.id == AuthorId);
            if (author is null)
                throw new InvalidOperationException(" Yazar bulanamadı");
          
            AuthorDetailViewModel vm =_mapper.Map<AuthorDetailViewModel>(author);
            return vm;
        }
    }
    public class AuthorDetailViewModel
    {
         public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } 
        
    }
}