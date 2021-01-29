using System;
using System.Collections.Generic;

namespace TripMapApi
{
    public class Sources{
        public string geometry { get; set; } 
        public List<string> attributes { get; set; } 
    }

    public class Bbox{
        public double lat_max { get; set; } 
        public double lat_min { get; set; } 
        public double lon_max { get; set; } 
        public double lon_min { get; set; } 
    }

    public class Info{
        public string descr { get; set; } 
        public string image { get; set; } 
        public int img_width { get; set; } 
        public string src { get; set; } 
        public int src_id { get; set; } 
        public int img_height { get; set; } 
    }

    public class DetailData{
        public string kinds { get; set; } 
        public Sources sources { get; set; } 
        public Bbox bbox { get; set; } 
        public Coords point { get; set; } 
        public string osm { get; set; } 
        public string otm { get; set; } 
        public string xid { get; set; } 
        public string name { get; set; } 
        public string wikipedia { get; set; } 
        public string image { get; set; } 
        public string wikidata { get; set; } 
        public string rate { get; set; } 
        public Info info { get; set; } 
    }

}