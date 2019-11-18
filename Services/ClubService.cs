using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using MongoDB.Driver;

namespace WebApi.Services
{
    public class ClubService
    {
        private readonly IMongoCollection<Club> _clubs;

        public ClubService()
        {
            var client = new MongoClient("mongodb://clubstoredb:n75sK59Xhr0adS0I@cluster0-shard-00-00-up9cm.mongodb.net:27017,cluster0-shard-00-01-up9cm.mongodb.net:27017,cluster0-shard-00-02-up9cm.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority");
            var database = client.GetDatabase("clubstoredb");

            _clubs = database.GetCollection<Club>("Clubs");
        }

        public List<Club> Get()
        {
            return _clubs.Find(club => true).ToList();
        }

        public Club Get(string id) =>
            _clubs.Find<Club>(club => club.Id==id).FirstOrDefault();

        public Club Create(Club club)
        {
            _clubs.InsertOne(club);
            return club;
        }

        public void Update(string id, Club clubIn)
        {
            _clubs.ReplaceOne(club => club.Id == id, clubIn);
        }

        public void Remove(Club clubIn)
        {
            _clubs.DeleteOne(club => club.Id == clubIn.Id);
        }

        public void Remove(string id) =>
            _clubs.DeleteOne(club => club.Id == id);

       
    }
}
