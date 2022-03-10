using Domain_CodigoPenal.Models;
using MediatR;
using System;

namespace CQRS_CodigoPenal.Commands
{
    public class AddUser : IRequest<Unit>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public static implicit operator User(AddUser user)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Password = user.Password,
                UserName = user.UserName
            };
        }
    }
}
