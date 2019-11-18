using WebApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public class EventService
    {
        private readonly IMongoCollection<Event> _events;

        public EventService()
        {
            var client = new MongoClient("mongodb://clubstoredb:n75sK59Xhr0adS0I@cluster0-shard-00-00-up9cm.mongodb.net:27017,cluster0-shard-00-01-up9cm.mongodb.net:27017,cluster0-shard-00-02-up9cm.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority");
            var database = client.GetDatabase("clubstoredb");

            _events = database.GetCollection<Event>("Events");
        }

        public List<Event> Get()
        {
            return _events.Find(new BsonDocument()).ToList();
        }

        public Event Get(string id)
        {
            return _events.Find<Event>(e => e.Id == id).FirstOrDefault();
        }

        public Event Create(Event e)
        {
            _events.InsertOne(e);
            return e;
        }

        public void Update(string id, Event eventIn)
        {
            _events.ReplaceOne(e => e.Id == id, eventIn);
        }

        public void Remove(Event eventIn)
        {
            _events.DeleteOne(category => category.Id == eventIn.Id);
        }

        public void Remove(string id)
        {
            _events.DeleteOne(e => e.Id == id);
        }
    }
}
