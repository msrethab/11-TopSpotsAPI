using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopSpotsApi.Models
{
    //Defining TopSpots Object with Properties Name, Description and Location
    public class TopSpot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double[] Location { get; set; }
    }
}