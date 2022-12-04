using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model {get; set;}
        public readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;
        public CreateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(X=>X.Name == Model.Name && X.Surname == Model.Surname);
            if( author is not null)
                throw new InvalidOperationException("Yazar zaten mevcut");
            author = _mapper.Map<Author>(Model); 
            _context.Authors.Add(author);
            _context.SaveChanges();

        }
    }
    public class CreateAuthorModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } 

    }
}