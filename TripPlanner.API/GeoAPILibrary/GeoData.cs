using System;
using System.Collections.Generic;

namespace GeoAPILibrary
{
    public class Coordinates
    {
        public double Lat { get; set; }
        public double Lon { get; set; }

        public Coordinates(double x, double y)
        {
            this.Lat = y;
            this.Lon = x;
        }

        public override string  ToString()
        {
            return "Latitude = "+this.Lat+" Longitude = "+this.Lon;
        }

    }
    public class GeoData
    {
        public string Address { get; set; }
        public Coordinates Coords { get; set; }

        public GeoData(Properties props){
            this.Address = props.formatted;
            this.Coords = new Coordinates(props.lon, props.lat);
        }
    }
}