using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TopSpotsApi.Models;

namespace TopSpotsApi.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "​*", methods: "*​")]
    public class TopSpotsController : ApiController
    {
        // GET: api/TopSpots
        public IEnumerable<TopSpot> Get()
        {
            //Read in json from file and returns array of TopSpots
            TopSpot[] TopSpots = JsonConvert.DeserializeObject<TopSpot[]>(File.ReadAllText(@"c:\dev\11-TopSpotsAPI\topspots.json"));
            return TopSpots;
        }

        // GET: api/TopSpots/5
        public TopSpot Get(int id)
        {
            //Read in json from file and returns specific TopSpot Requested
            TopSpot[] TopSpots = JsonConvert.DeserializeObject<TopSpot[]>(File.ReadAllText(@"c:\dev\11-TopSpotsAPI\topspots.json"));
            return TopSpots[id];
        }

        // POST: api/TopSpots
        public TopSpot Post(TopSpot TopSpot)
        {
            //Read in json from file and store in array, create new array one index larger and append parameter TopSpot to end
            TopSpot[] TopSpots = JsonConvert.DeserializeObject<TopSpot[]>(File.ReadAllText(@"c:\dev\11-TopSpotsAPI\topspots.json"));
            TopSpot[] addTopSpots = new TopSpot[TopSpots.Length + 1];
            TopSpots.CopyTo(addTopSpots, 0);
            addTopSpots.SetValue(TopSpot, TopSpots.Length);
            TopSpots = addTopSpots;

            //Serialize TopSpots and write to file as json before returning new TopSpots with added term
            string TopSpotsString = JsonConvert.SerializeObject(TopSpots, Formatting.Indented);
            File.WriteAllText(@"c:\dev\11-TopSpotsAPI\topspots.json", TopSpotsString);
            return TopSpot;
        }

        // PUT: api/TopSpots/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TopSpots/5
        public TopSpot Delete(int id)
        {
            //Read in json from file and store in array, creat new array one index smaller and store deleted topspot data
            TopSpot[] TopSpots = JsonConvert.DeserializeObject<TopSpot[]>(File.ReadAllText(@"c:\dev\11-TopSpotsAPI\topspots.json"));
            TopSpot[] DeleteTopSpot = new TopSpot[TopSpots.Length - 1];
            TopSpot DelTopSpot = TopSpots[id];

            //Copying in TopSpot data from TopSpots array omitting the value and index id
            int i = 0;
            int j = 0;
            while (i < TopSpots.Length)
            {
                if (i != id)
                {
                    DeleteTopSpot[j] = TopSpots[i];
                    j++;
                }

                i++;
            }
            TopSpots = DeleteTopSpot;

            //Writing new TopSpot array to File and returning deleted term
            string TopSpotsString = JsonConvert.SerializeObject(TopSpots, Formatting.Indented);
            File.WriteAllText(@"c:\dev\11-TopSpotsAPI\topspots.json", TopSpotsString);
            return DelTopSpot;
        }
    }
}
