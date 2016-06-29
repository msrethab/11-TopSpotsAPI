using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopSpotsApi.Models
{
    public class TopSpot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double[] Location { get; set; }
    }
}