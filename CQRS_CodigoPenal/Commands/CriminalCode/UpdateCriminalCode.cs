using Domain_CodigoPenal.Models;
using MediatR;
using System;

namespace CQRS_CodigoPenal.Commands
{
    public class UpdateCriminalCode :IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid UpdateUserId { get; set; }

        public static implicit operator CriminalCode(UpdateCriminalCode criminalCode) {
            return new CriminalCode()
            {
                Id = criminalCode.Id,
                StatusId = criminalCode.Status,
                Penalty = criminalCode.Penalty,
                PrisonTime = criminalCode.PrisonTime,
                UpdateDate = DateTime.Now,
                UpdateUserId = criminalCode.UpdateUserId
            };
        }
    }
}
