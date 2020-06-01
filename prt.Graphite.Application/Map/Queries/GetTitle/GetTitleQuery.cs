using MediatR;
using Prt.Graphit.Application.Map.Queries.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Application.Map.Queries.GetTitle
{
    public class GetTitleQuery : IRequest<FileContainer>
    {
        public string Z { get; private set; }
        public string X { get; private set; }
        public string Y { get; private set; }

        public GetTitleQuery(string z, string x, string y)
        {
            Z = z;
            X = x;
            Y = y;
        }
    }
}
