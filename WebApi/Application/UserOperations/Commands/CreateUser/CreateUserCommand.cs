using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi;
using AutoMapper;

namespace Webapi.Application.UserOperations.Commnads.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model {get; set;}
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserCommand(IBookStoreDbContext Context, IMapper mapper)
        {
            _context = Context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x =>x.Email == Model.Email);
            if(user is not null)
                throw new InvalidOperationException("Kullanıcı zaten mevcut");
            user = _mapper.Map<User>(Model); 
            _context.Users.Add(user);
            _context.SaveChanges();
           

        }
        public class CreateUserModel
        {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        }
    }

}