using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.GetAuthors
{
    public class GetAuthorQuery
    {
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetAuthorQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
           public List<AuthorViewModel> Handle()
        {
              var authors = _context.Authors.OrderBy(X => X.id);
            List<AuthorViewModel> returnobj = _mapper.Map<List<AuthorViewModel>>(authors);
            return returnobj;
           

        }

    }
    public class AuthorViewModel
    {
         public int id { get; set; }   
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; } 

    }
}