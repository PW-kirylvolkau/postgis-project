using System;
using System.Collections.Generic;

namespace GeoAPILibrary
{
     public class Datasource    {
        public string sourcename { get; set; } 
        public string attribution { get; set; } 
        public string license { get; set; } 
        public string url { get; set; } 
    }

    public class Rank    {
        public double importance { get; set; } 
        public int confidence { get; set; } 
        public string match_type { get; set; } 
    }

    public class Properties    {
        public Datasource datasource { get; set; } 
        public string name { get; set; } 
        public string city { get; set; } 
        public string state { get; set; } 
        public string postcode { get; set; } 
        public string country { get; set; } 
        public string country_code { get; set; } 
        public double lon { get; set; } 
        public double lat { get; set; } 
        public string formatted { get; set; } 
        public string address_line1 { get; set; } 
        public string address_line2 { get; set; } 
        public string result_type { get; set; } 
        public Rank rank { get; set; } 
        public string place_id { get; set; } 
        public string county { get; set; } 
        public string village { get; set; } 
    }

    public class Geometry    {
        public string type { get; set; } 
        public List<double> coordinates { get; set; } 
    }

    public class Feature    {
        public string type { get; set; } 
        public Properties properties { get; set; } 
        public List<double> bbox { get; set; } 
        public Geometry geometry { get; set; } 
    }

    public class Parsed    {
        public string city { get; set; } 
        public string expected_type { get; set; } 
    }

    public class Query    {
        public string text { get; set; } 
        public Parsed parsed { get; set; } 
    }

    public class Root    {
        public List<Feature> features { get; set; } 
        public string type { get; set; } 
        public Query query { get; set; } 
    }
}