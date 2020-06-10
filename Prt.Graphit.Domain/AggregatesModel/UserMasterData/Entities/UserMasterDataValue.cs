using Newtonsoft.Json;
using Prt.Graphit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prt.Graphit.Domain.AggregatesModel.UserMasterData.Entities
{
    /// <summary>
    /// Таблица данных (записей) пользовательского справочника
    /// по его полям
    /// </summary>
    public class UserMasterDataValue : Entity
    {
        protected UserMasterDataValue() 
        {

        }
        public UserMasterDataValue(Guid userMasterDataId,
            Guid userMasterDataFieldId, 
            UserMasterDataContent content)
        {
            Id = Guid.NewGuid();
            UserMasterDataId = userMasterDataId;
            UserMasterDataFieldId = userMasterDataFieldId;
            _content = JsonConvert.SerializeObject(content);
        }
        /// <summary>
        /// Уникальный Guid
        /// </summary>
        public override Guid Id { get; protected set; }        
        /// <summary>
        /// Ссылка на Пользовательский справочник
        /// </summary>
        public Guid UserMasterDataId { get; private set; }
        public UserMasterData UserMasterData { get; private set; }
        /// <summary>
        /// Ссылка на поле пользовательского справочника
        /// </summary>
        public Guid UserMasterDataFieldId { get; private set; }
        public UserMasterDataField UserMasterDataField { get; private set; }
        /// <summary>
        /// Ссылка на ВВТ
        /// </summary>
        public Guid VehicleId { get; private set; }
        /// <summary>
        /// Значения в jsonb
        /// </summary>
        private string _content;
        public UserMasterDataContent Content 
            => JsonConvert.DeserializeObject<UserMasterDataContent>(_content);
    }

    public class UserMasterDataContent 
    {
        /// <summary>
        /// Значение в jsonb
        /// </summary>
        public dynamic Value { get; set; }
    }
}
