using MediatR;

namespace Prt.Graphit.Application.LevelManagement.Commands.AddLevelManagement
{
    public class AddLevelManagementCommand : IRequest<Unit>
    {
        public string Name { get; }
        public string Code { get; }
        public bool IsVCH { get; }
        public bool Independent { get; }

        public AddLevelManagementCommand(string name, string code, bool isVCH, bool independent)
        {
            Name = name;
            Code = code;
            IsVCH = isVCH;
            Independent = independent;
        }
    }
}
