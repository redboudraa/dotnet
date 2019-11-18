using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }
       // [BsonElement("StartDate")]
        public string startDate { get; set; }
       // [BsonElement("EndDate")]
        public string endDate{ get; set; }

       // [BsonElement("Place")]
        public string Place { get; set; }

       // [BsonElement("Description")]
        public string Description { get; set; }
    }
}
