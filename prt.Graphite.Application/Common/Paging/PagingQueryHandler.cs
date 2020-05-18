using AutoMapper;
using MediatR;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Common.Paging
{
    public abstract class PagingQueryHandler<TQ, TCM, TM> : HandlerQueryBase<TQ, TCM>
        where TQ : IRequest<TCM>
        where TCM : CollectionViewModel<TM>, new()
    {
        protected PagingQueryHandler(IAppDbContext applicationDbContext, IMapper mapper)
            : base(applicationDbContext, mapper)
        {
        }

        public abstract override Task<TCM> Handle(TQ request, CancellationToken cancellationToken);
    }
}
