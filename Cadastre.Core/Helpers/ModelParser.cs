using Cadastre.Core.DataAccess.Entities;
using Cadastre.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities = Cadastre.Core.DataAccess.Entities;

namespace Cadastre.Core.Helpers
{
    /// <summary>
    /// Класс для преобразования сущностей и моделей Клиентов
    /// </summary>
    public static class ModelParser
    {
        /// <summary>
        /// Преобразование Сущности в Модель 
        /// </summary>
        /// <param name="entity"> Сущность </param>
        /// <returns> Модель </returns>
        public static Models.Client ToDto(this Entities.Client entity)
        {
            return new Models.Client
            {
                ClientId = entity.Id,
                ClientName = entity.Name,
                TypeClient = entity.Type,
                ActualAddress = entity.ActualAddress,
                Country = entity.Country,
                INN = entity.INN,
                LegalAddress = entity.LegalAddress,
                MailingAddress = entity.MailingAddress,
                IsBlackListed=entity.IsBlackListed
            };
        }

        /// <summary>
        /// Преобразование Модели в Сущность
        /// </summary>
        /// <param name="entity"> Модель </param>
        /// <returns> Сущность </returns>
        public static Entities.Client ToEntity(this Models.Client dto)
        {
            return new Entities.Client
            {
                Id = dto.ClientId,
                Name = dto.ClientName,
                Type = dto.TypeClient,
                INN = dto.INN,
                LegalAddress = dto.LegalAddress,
                ActualAddress = dto.ActualAddress,
                MailingAddress = dto.LegalAddress,
                Country = dto.Country,
                IsBlackListed=dto.IsBlackListed
            };
        }
    }
}
