using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BusinessEntities
{
    public class City
    {
        public ObjectId _id { get; set; }
        public String Name { get; set; }
        public String County { get; set; }

        public CityInformation Information { get; set; }
    }
}
