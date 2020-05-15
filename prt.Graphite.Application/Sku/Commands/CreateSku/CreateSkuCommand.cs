using MediatR;
using Prt.Graphit.Application.Common.Response;
using System;
using System.Collections.Generic;

namespace Prt.Graphit.Application.Sku.Commands.CreateSku
{
    public class CreateSkuCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; private set; }
        public Guid? ParentId { get; private set; }
        public CreateSkuGroup SkuGroup { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<CreateSkuUnit> Units { get; private set; }

        public string Designation { get; private set; }
        public CreateSkuType SkuType { get; private set; }
        public string Description { get; private set; }

        public CreateSkuCommand(Guid id, Guid? parentId, CreateSkuGroup skuGroup, string name, IEnumerable<CreateSkuUnit> units, string designation, CreateSkuType skuType, string description)
        {
            Id = id;
            ParentId = parentId;
            SkuGroup = skuGroup;
            Name = name;
            Units = units;
            Designation = designation;
            SkuType = skuType;
            Description = description;
        }
    }

    public class CreateSkuUnit
    {
        public string Name { get; private set; }
        public Guid SkuId { get; private set; }
        public decimal Coefficient { get; private set; }
        public bool Base { get; private set; }

        public CreateSkuUnit(string name, Guid skuId, decimal coefficient, bool @base)
        {
            Name = name;
            SkuId = skuId;
            Coefficient = coefficient;
            Base = @base;
        }
    }

    public class CreateSkuGroup
    {
        public Guid Id { get; protected set; }
        public Guid? ParentId { get; protected set; }
        public string Name { get; private set; }

        public CreateSkuGroup(Guid id, Guid? parentId, string name)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
        }
    }

    public class CreateSkuType
    {
        public Guid Id { get; protected set; }
        public string Name { get; private set; }

        public CreateSkuType(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
