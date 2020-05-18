using AutoMapper;
using MediatR;
using Prt.Graphit.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Common.Handlers
{
    public abstract class HandlerQueryBase<TQ, TM> : HandlerBase<TQ, TM>
        where TQ : IRequest<TM>
    {
        protected IMapper AutoMapper { get; private set; }

        protected HandlerQueryBase(IAppDbContext appDbContext,  IMapper mapper)
            : base(appDbContext)
        {
            AutoMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
