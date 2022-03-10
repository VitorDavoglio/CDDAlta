using CQRS_CodigoPenal.Results;
using MediatR;

namespace CQRS_CodigoPenal.Commands
{
    public class AuthUser: IRequest<AuthResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
