using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        public readonly IBookStoreDbContext _context ;
        public readonly  IMapper _mapper ;
        public GetAuthorDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.id == AuthorId);
            if (author is null)
                throw new InvalidOperationException(" Yazar bulanamad─▒");
          
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