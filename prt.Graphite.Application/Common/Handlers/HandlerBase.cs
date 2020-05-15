using MediatR;
using Prt.Graphit.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Prt.Graphit.Application.Common.Handlers
{
    public abstract class HandlerBase<TQ, TM> : IRequestHandler<TQ, TM>
        where TQ : IRequest<TM>
    {
        protected ISkuDbContext ContextDb { get; private set; }

        //protected ICurrentUserService CurrentUserService { get; private set; }

        protected HandlerBase(ISkuDbContext skuDbContex)
        {
            ContextDb = skuDbContex ?? throw new ArgumentNullException(nameof(skuDbContex));
            //CurrentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public abstract Task<TM> Handle(TQ request, CancellationToken cancellationToken);
    }
}
