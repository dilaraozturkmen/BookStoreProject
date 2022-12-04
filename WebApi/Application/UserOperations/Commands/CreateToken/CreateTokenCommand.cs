using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi;
using AutoMapper;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace Webapi.Application.UserOperations.Commnads.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model {get; set;}
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x=>x.Email == Model.Email && x.Password == Model.Password);
            if(user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken= token.RefreshToken;
                user.RefreshTokenExpireDate= token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı adı veya şifre hatalı.");
            }
        }
    }
    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}