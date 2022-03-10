using CQRS_CodigoPenal.Commands;
using CQRS_CodigoPenal.Results;
using Domain_CodigoPenal.Interfaces;
using Domain_CodigoPenal.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Prestadores.Domain.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_CodigoPenal.Handlers
{
    public class UserHandler : IRequestHandler<AddUser>, IRequestHandler<AuthUser, AuthResult>
    {
        private readonly ILogger<UserHandler> _log;
        private readonly IRepository<User> _userRepo;
        private readonly IExceptionBuilder _ex;

        public UserHandler(ILogger<UserHandler> log, IRepository<User> userRepo, IExceptionBuilder ex)
        {
            _log = log;
            _userRepo = userRepo;
            _ex = ex;
        }

        public async Task<Unit> Handle(AddUser request, CancellationToken cancellationToken)
        {
            await _userRepo.Create(request);
            return Unit.Value;
        }

        public async Task<AuthResult> Handle(AuthUser request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.FirstOrDefault(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, request.UserName.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var stringToken = tokenHandler.WriteToken(token);
                return new AuthResult(request.UserName, stringToken);
            }
            else throw _ex.Build(HttpStatusCode.Unauthorized);
        }
    }
}
