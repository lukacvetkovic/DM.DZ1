using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiyInsertInMongo.Models
{
    public class RootObject
    {
        public List<CityInformation> results { get; set; }
        public string status { get; set; }
    }
}
