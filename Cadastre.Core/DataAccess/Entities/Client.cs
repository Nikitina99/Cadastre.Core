using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastre.Core.DataAccess.Entities
{
    /// <summary>
    /// Класс сущности Клиент
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Идентификаор уникальный
        /// </summary>
        [Key]
        public int Id { get; set; }    
        /// <summary>
        /// Наименование клиента
        /// </summary>
        public string Name { get; set; }        
        /// <summary>
        /// Тип клиента
        /// </summary>
        public string Type { get; set; }    
        /// <summary>
        /// ИНН
        /// </summary>
        public string INN { get; set; }   
        /// <summary>
        /// Юридический адрес
        /// </summary>
        public string LegalAddress { get; set; } 
        /// <summary>
        /// Фактический адрес
        /// </summary>
        public string ActualAddress { get; set; }  
        /// <summary>
        /// Почтовый адрес
        /// </summary>
        public string MailingAddress { get; set; }    
        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Принаддежность к черному списку
        /// </summary>
        public string IsBlackListed { get; set; }
    }
}
