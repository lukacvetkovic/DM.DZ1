using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CitiyInsertInMongo.Helpers;
using CitiyInsertInMongo.Models;
using DataModel.GenericRepository;
using MongoDB.Bson;

namespace CitiyInsertInMongo
{
    class Program
    {
        private static string DECODERURL = "http://maps.google.com/maps/api/geocode/json?address=";

        static void Main(string[] args)
        {
            MongoDbRepository repo = new MongoDbRepository();
            var lines = File.ReadAllLines("gradovi.csv", Encoding.Default).Select(a => a.Split(';'));

            foreach (var line in lines)
            {
                if (line[1] == "Grad")
                {
                    String name = line[2];
                    String country = line[0];


                    String response = GetHelper(DECODERURL + name + "," + "Hrvatska");

                    RootObject c = JSONHelper.Deserialize<RootObject>(response);

                    if (c.status == "OK")
                    {
                        City city = new City() { County = country, Information = c.results.First(), Name = name };

                        repo.AddOneSync(city);
                    }
                    else
                    {
                        Console.WriteLine(name + ", " + country);
                    }

                    Thread.Sleep(1000);

                }
            }
            Console.WriteLine("Gotovo!");
            Console.ReadLine();



        }

        static string GetHelper(string uri)
        {
            using (WebResponse wr = WebRequest.Create(uri).GetResponse())
            {
                using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
