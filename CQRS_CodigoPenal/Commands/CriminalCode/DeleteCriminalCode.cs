using MediatR;
using System;

namespace CQRS_CodigoPenal.Commands
{
    public class DeleteCriminalCode :IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
