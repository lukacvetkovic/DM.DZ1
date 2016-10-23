using System;

namespace CitiyInsertInMongo.Models
{
    public class City
    {
        public String Name { get; set; }
        public String County { get; set; }

        public CityInformation Information { get; set; }
    }
}
