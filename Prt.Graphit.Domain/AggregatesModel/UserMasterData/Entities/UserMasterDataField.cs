using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Domain.AggregatesModel.UserMasterData.Entities
{
    /// <summary>
    /// Поле пользовательского справочника
    /// </summary>
    public class UserMasterDataField : Entity
    {
        protected UserMasterDataField() { }
        public UserMasterDataField(Guid userMasterDataId, string nameField, Guid typeUserMasterDataId)
        {
            Id = Guid.NewGuid();
            UserMasterDataId = userMasterDataId;
            NameField = nameField;
            TypeUserMasterDataId = typeUserMasterDataId;
        }
        /// <summary>
        /// Уникальный Guid
        /// </summary>
        public override Guid Id { get; protected set; }
        /// <summary>
        /// Ссылка на Пользовательский справочник
        /// </summary>
        public Guid UserMasterDataId { get; private set; }
        /// <summary>
        /// Наименование поля
        /// </summary>
        public string NameField { get; private set; }

        /// <summary>
        /// Ссылка на справочник тип данных
        /// </summary>
        public Guid TypeUserMasterDataId { get; private set; }
        public TypeUserMasterData TypeUserMasterData { get; private set; }

        public void Update(string nameField, Guid typeUserMasterDataId)
        {
            NameField = nameField;
            TypeUserMasterDataId = typeUserMasterDataId;
        }
    }
}
