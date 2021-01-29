using System;

namespace TripMapApi
{
    public class Coords
    {
        public double lon { get; set; }
        public double lan { get; set; }
    }

    public class RadiusData
    {
        public string xid { get; set; } 
        public string name { get; set; } 
        public double dist { get; set; } 
        public int rate { get; set; } 
        public string wikidata { get; set; } 
        public string kinds { get; set; } 
        public Coords point { get; set; } 
        public string osm { get; set; } 
    }

}