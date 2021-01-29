using System;


namespace TripMapApi
{
    public class GeoData
    {
        public string name { get; set; }
        public string country { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public int population { get; set; }
        public string timezone { get; set; }
        public string status { get; set; }


        public override string ToString()
        {
            return "Name: "+this.name+"\nCountry: "+this.country+"\nLatitude: "+this.lat+"\nLongitude: "+
            this.lon+"\nPopulation: "+this.population+"\nTimezone: "+this.timezone+"\nStatus: "+this.status;
        }
    }
}