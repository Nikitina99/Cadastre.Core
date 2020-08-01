using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastre.Core.DataAccess.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }      
        public string Name { get; set; }        
        public string Type { get; set; }       
        public string INN { get; set; }        
        public string LegalAddress { get; set; }       
        public string ActualAddress { get; set; }     
        public string MailingAddress { get; set; }        
        public string Country { get; set; }
    }
}
