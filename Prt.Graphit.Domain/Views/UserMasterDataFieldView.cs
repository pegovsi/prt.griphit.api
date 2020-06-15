using System;

namespace Prt.Graphit.Domain.Views
{
    public class UserMasterDataFieldView
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid VehicleModelId { get; private set; }
        public string NameField { get; private set; }
        public Guid TypeDataId { get; private set; }
        public string TypeData { get; private set; }
        public string Description { get; private set; }

        public static string View => "user_master_data_field_view";
    }
}
