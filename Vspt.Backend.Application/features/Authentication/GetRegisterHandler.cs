using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

using System.Text;
using Vspt.BackEnd.Application.features.Authentication.Helpers;
using Vspt.Box.MediatR;
using Vspt.BackEnd.Domain.Contract;
using Vspt.BackEnd.Domain.Entity;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading;
using Vspt.BackEnd.Application.features.Authentication;
using Vspt.BackEnd.Application.features.Authentication.DTO;

namespace Vspt.BackEnd.Application.Authentication.Auth
{
    public sealed record GetRegisterRequest : BaseRequest<GetLoginRequestItem, Unit>
    {
    }
    internal sealed class GetRegisterHandler : BaseRequestHandler<GetRegisterRequest, GetLoginRequestItem, Unit>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
      

        public GetRegisterHandler(IMapper mapper,  IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
         
        }

        protected override async Task<Unit> HandleData(GetLoginRequestItem request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ValidationException("Bad request");
           
            if (await CheckUserNameExistAsnc(request.Username))
                throw new ValidationException($"Username {request.Username} уже есть в базе!");
           
            //check Email
            if (await CheckUserEmailExistAsnc(request.Email))
                throw new ValidationException($"Email {request.Email} уже есть в базе!");
           

            //check Passw
            var pass = CheckPasswordExistAsnc(request.Password);
            if(!string.IsNullOrEmpty(pass))
                throw new ValidationException($"Пароль {request.Password}  некорректен!");


            request.Password = PasswordHasher.HashPassword(request.Password);
            request.Role = "User";
            request.Token = "";
            var user= _mapper.Map<User>(request);
            await _usersRepository.Add(user, cancellationToken);
            
            return Unit.Value;           
        }
        private Task<bool> CheckUserNameExistAsnc(string userName)

            => _usersRepository.GetAnyName(userName);
        

        private Task<bool> CheckUserEmailExistAsnc(string Email)

            => _usersRepository.GetAnyEmail(Email); 
          

        private string CheckPasswordExistAsnc(string Password)
        {
            StringBuilder sb = new StringBuilder();
            if (Password.Length < 8)
                sb.Append("Minimum password lenght should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(Password, "[a-z]") && Regex.IsMatch(Password, "[A-Z]") && Regex.IsMatch(Password, "[0-9]")))
                sb.Append("Password should be Alphanumeric" + Environment.NewLine);
            if (!(Regex.IsMatch(Password, "[<,>,&]")))
                sb.Append("Password should be AlphanumericNew" + Environment.NewLine);
            return sb.ToString();
        
        }
    }
}
