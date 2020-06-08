using MediatR;
using Prt.Graphit.Application.Common.Paging;
using Prt.Graphit.Application.LevelManagement.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.LevelManagement.Queries.GetLevelManagementPage
{
    public class GetLevelManagementPage : IRequest<LevelManagementCollectionViewModel>
    {
        public PageContext<LevelManagementPageFilter> Context { get; }

        public GetLevelManagementPage(PageContext<LevelManagementPageFilter> context)
        {
            Context = context;
        }
    }
}
