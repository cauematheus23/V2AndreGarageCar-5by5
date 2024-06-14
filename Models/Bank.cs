using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Bank
    {
        [BsonId]
        [Key]
        public string CNPJ { get; set; }    
        public string Name { get; set; }
        public DateTime FoundingDate { get; set; }
    }
}
