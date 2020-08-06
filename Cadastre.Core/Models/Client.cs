using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cadastre.Core.Models
{
    public class Client
    {
        [JsonPropertyName("ClientId")]
        public int ClientId { get; set; }


        [Display(Name = "Клиент")]
        [JsonPropertyName("ClientName")]
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string ClientName { get; set; }

        [Display(Name = "Тип клиента")]
        [JsonPropertyName("TypeClient")]
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string TypeClient { get; set; }

        [Display(Name = "ИНН")]
        [JsonPropertyName("INN")]
        [StringLength(10, ErrorMessage = "Должен состоять из 10 цифр.")]
        public string INN { get; set; }

        [Display(Name = "Юридический адрес")]
        [JsonPropertyName("LegalAddress")]
        public string LegalAddress { get; set; }

        [Display(Name = "Фактический адрес")]
        [JsonPropertyName("ActualAddress")]
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string ActualAddress { get; set; }

        [Display(Name = "Почтовый адрес")]
        [JsonPropertyName("MailingAddress")]
        public string MailingAddress { get; set; }

        [Display(Name = "Страна")]
        [JsonPropertyName("Country")]
        public string Country { get; set; }

        [Display(Name = "В черном списке:")]
        [JsonPropertyName("IsBlackListed")]
        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        public string IsBlackListed { get; set; }
    }
}
