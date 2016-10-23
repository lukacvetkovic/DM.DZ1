using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class City
    {
        public String Name { get; set; }
        public String County { get; set; }

        public CityInformation Information { get; set; }
    }
}
