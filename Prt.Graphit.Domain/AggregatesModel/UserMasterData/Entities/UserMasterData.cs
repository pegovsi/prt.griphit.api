using Prt.Graphit.Domain.Common;
using Prt.Graphit.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prt.Graphit.Domain.AggregatesModel.UserMasterData.Entities
{
    /// <summary>
    /// Пользовательский справочник
    /// </summary>
    public class UserMasterData : Entity, IAggregateRoot
    {
        protected UserMasterData() 
        {
            _userMasterDataFields = new List<UserMasterDataField>();
        }
        public UserMasterData(Guid vehicleModelId, string name)
            : this()
        {
            Id = Guid.NewGuid();
            VehicleModelId = vehicleModelId;
            Name = name;
        }
        /// <summary>
        /// Уникальный Guid
        /// </summary>
        public override Guid Id { get; protected set; }
        /// <summary>
        /// Модель ВВТ
        /// </summary>
        public Guid VehicleModelId { get; private set; }
        /// <summary>
        /// Наименование пользовательского справочника
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Коллекция полей таблицы
        /// </summary>
        private List<UserMasterDataField> _userMasterDataFields;
        public IReadOnlyCollection<UserMasterDataField> UserMasterDataFields => _userMasterDataFields;

        ///Функционал 1 - Создание справочника
        public void AddField(string nameField, Guid typeUserMasterDataId)
        {
            ///Если поле с именем {{ nameField }} уже существует, выдать ошибку
            if (_userMasterDataFields.FirstOrDefault(x => x.NameField == nameField) != null)
            {
                throw new ExistsDataException($"Запись с именем {nameField} уже существует");
            }

            var field = new UserMasterDataField
            (
                userMasterDataId: this.Id,
                nameField: nameField,
                typeUserMasterDataId: typeUserMasterDataId
            );

            _userMasterDataFields.Add(field);
        }
        public void DeleteField(Guid userMasterDataFieldId)
        {
            var field = _userMasterDataFields.FirstOrDefault(x => x.Id == userMasterDataFieldId);
            if (field != null)
            {
                _userMasterDataFields.Remove(field);
            }
            //TODO: Добавить доменное событие на удаления записей по этому полю
        }
        public void UpdateField(Guid userMasterDataFieldId, string nameField, Guid typeUserMasterDataId)
        {
            var field = _userMasterDataFields
                .FirstOrDefault(x => x.Id == userMasterDataFieldId);
            if (field != null)
            {
                field.Update(nameField, typeUserMasterDataId);
            }
            //TODO: Добавить доменное событие на удаления записей по этому полю
        }

        public void SetName(string name)
        {
            if (Name != name)
            {
                Name = name;
            }
        }



        ///Функционал 2 - заполнение данных
        ///
    }
}
