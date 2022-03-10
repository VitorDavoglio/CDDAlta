using CQRS_CodigoPenal.Commands;
using CQRS_CodigoPenal.Queries;
using CQRS_CodigoPenal.Results;
using Domain_CodigoPenal.Interfaces;
using Domain_CodigoPenal.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Prestadores.Domain.Interfaces;
using System.Linq.Dynamic.Core;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;

namespace CQRS_CodigoPenal.Handlers
{
    public class CriminalCodeHandler : IRequestHandler<AddCriminalCode>, IRequestHandler<UpdateCriminalCode>, IRequestHandler<CriminalCodeQuery, PaginationResult<CriminalCode>>, IRequestHandler<DeleteCriminalCode>
    {
        private readonly ILogger<CriminalCodeHandler> _log;
        private readonly IRepository<CriminalCode> _criminalCodeRepo;
        private readonly IExceptionBuilder _ex;

        public CriminalCodeHandler(ILogger<CriminalCodeHandler> log, IRepository<CriminalCode> criminalCodeRepo, IExceptionBuilder ex)
        {
            _log = log;
            _criminalCodeRepo = criminalCodeRepo;
            _ex = ex;
        }

        public async Task<Unit> Handle(AddCriminalCode request, CancellationToken cancellationToken)
        {
            await _criminalCodeRepo.Create(request);
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateCriminalCode request, CancellationToken cancellationToken)
        {
            await _criminalCodeRepo.Update(request);
            return Unit.Value;
        }

        public async Task<PaginationResult<CriminalCode>> Handle(CriminalCodeQuery request, CancellationToken cancellationToken)
        {
            var results = _criminalCodeRepo.Where(x => !request.Id.HasValue || x.Id == request.Id.Value &&
                                            !request.StatusId.HasValue || x.StatusId == request.StatusId.Value &&
                                            !request.CreateUserId.HasValue || x.CreateUserId == request.CreateUserId.Value &&
                                            !request.CreateUserId.HasValue || x.UpdateUserId == request.UpdateUserId.Value &&
                                            string.IsNullOrWhiteSpace(request.Name) || x.Name == request.Name &&
                                            string.IsNullOrWhiteSpace(request.Description) || x.Description == request.Description &&
                                            !request.Penalty.HasValue || x.Penalty == request.Penalty.Value &&
                                            !request.PrisonTime.HasValue || x.PrisonTime == request.PrisonTime.Value &&
                                            !request.CreateDate.HasValue || x.CreateDate == request.CreateDate.Value &&
                                            !request.UpdateDate.HasValue || x.UpdateDate == request.UpdateDate.Value);


            if (request.Sort != null && request.Sort.OrderQuery != null)
                results.OrderBy(request.Sort.OrderQuery);


            results.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

            return new PaginationResult<CriminalCode>()
            {
                Items = results.ToList(),
                PageSize = request.PageSize,
                CurrentPage = request.PageNumber,
                TotalItems = _criminalCodeRepo.Count()
            };
        }

        public async Task<Unit> Handle(DeleteCriminalCode request, CancellationToken cancellationToken)
        {
            await _criminalCodeRepo.Delete(x => x.Id == request.Id);
            return Unit.Value;
        }
    }
}
