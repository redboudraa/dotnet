using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ClubsDataBaseStoreSettings : IClubsStoreDatabaseSettings
    {
        public string ClubsCollectionName { get ; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set ; }
    }
    public interface IClubsStoreDatabaseSettings
    {
        string ClubsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
