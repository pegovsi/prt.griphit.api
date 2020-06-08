using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Prt.Graphit.Application.Crew.Commands.AddCrew
{
    public class AddCrewCommandValidator : AbstractValidator<AddCrewCommand>
    {
        public AddCrewCommandValidator()
        {
            RuleFor(x => x.MilitaryFormationId).NotEmpty();
            RuleFor(x => x.OrderNumber).NotEmpty();
            RuleFor(x => x.VehicleId).NotEmpty();
        }
    }
}
