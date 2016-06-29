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
            TopSpot[] TopSpots = JsonConvert.DeserializeObject<TopSpot[]>(File.ReadAllText(@"c:\dev\11-TopSpotsAPI\topspots.json"));
            return TopSpots;
        }

        // GET: api/TopSpots/5
        public TopSpot Get(int id)
        {
            TopSpot[] TopSpots = JsonConvert.DeserializeObject<TopSpot[]>(File.ReadAllText(@"c:\dev\11-TopSpotsAPI\topspots.json"));
            return TopSpots[id];
        }

        // POST: api/TopSpots
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TopSpots/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TopSpots/5
        public void Delete(int id)
        {
        }
    }
}
