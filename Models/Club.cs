using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{

    public class Club
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }
        public string Password { get; set; }
        public string Logo { get; set; }
    }
}

