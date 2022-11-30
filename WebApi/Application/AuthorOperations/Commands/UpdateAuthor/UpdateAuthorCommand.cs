using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.UpdateAuthor
{
    public class UpdateAuthorCommand
    {

        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public UpdateAuthorModel Model { get; set; }
        public int authorId;
        public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            Author author = _context.Authors.SingleOrDefault(x=> x.id == authorId);
            if (author is null)
                throw new InvalidOperationException("yazar bulanamadı");

            if(_context.Authors.Any(x=> x.Name == Model.Name.ToLower() && x.Surname != Model.Surname.ToLower()))
                throw new InvalidOperationException("Aynı isimli bir yazar zaten mevcut");
            _mapper.Map(Model,author);
           
            _context.SaveChanges();

        }

    }
    public class UpdateAuthorModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } 

    }
}