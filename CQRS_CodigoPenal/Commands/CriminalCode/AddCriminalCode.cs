using Domain_CodigoPenal.Models;
using MediatR;
using System;

namespace CQRS_CodigoPenal.Commands
{
    public class AddCriminalCode : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public Guid CreateUserId { get; set; }

        public static implicit operator CriminalCode(AddCriminalCode criminalCode) {
            return new CriminalCode()
            {
                Id = Guid.NewGuid(),
                StatusId =  1,
                Name = criminalCode.Name,
                Description = criminalCode.Description,
                Penalty = criminalCode.Penalty,
                PrisonTime = criminalCode.PrisonTime,
                CreateDate = DateTime.Now,
                CreateUserId = criminalCode.CreateUserId,
            };
        }
    }
}
