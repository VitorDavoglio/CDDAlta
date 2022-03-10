using CQRS_CodigoPenal.Results;
using Domain_CodigoPenal.Models;
using MediatR;
using System;
using System.Linq.Expressions;

namespace CQRS_CodigoPenal.Queries
{
    public class CriminalCodeQuery : PagedQuery<CriminalCode>, IRequest<PaginationResult<CriminalCode>>
    {
        public Guid? Id { get; set; }
        public int? StatusId { get; set; }
        public Guid? CreateUserId { get; set; }
        public Guid? UpdateUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Penalty { get; set; }
        public int? PrisonTime { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }

}
