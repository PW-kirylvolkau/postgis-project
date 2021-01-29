using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace TripMapApi
{
    public static class TripMapFunctions
    {
        public static string apiKey = "5ae2e3f221c38a28845f05b6b0e9e0c53c290b7199c0b04bcd426afe";
        public static async Task<string> apiGet(string method, string query)
        {
            HttpClient client = new HttpClient();
            var url = "https://api.opentripmap.com/0.1/en/places/"+method+"?apikey="+apiKey+"&"+query;
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public static async Task<GeoData> GetGeoData(string geoname)
        {
            var jsonResponse = await apiGet("geoname","name="+geoname);
            var geoDataObject = JsonConvert.DeserializeObject<GeoData>(jsonResponse);
            return geoDataObject;
        }

        public static async Task<List<RadiusData>> GetRadiusData(double lat, double lon)
        {
            var defaultPageLength = 5;
            var defaultOffset = 0;
            var jsonResponse = await apiGet(
                "radius",
                "radius=1000&limit="+defaultPageLength+"&offset="+defaultOffset+"&lon="+lon+"&lat="+lat+"&rate=2&format=json"
                );
            var radiusDataList = JsonConvert.DeserializeObject<List<RadiusData>>(jsonResponse);
            return radiusDataList;
        }

        public static async Task<DetailData> GetDetailData(string xid)
        {
            var jsonResponse = await apiGet("xid/"+xid,"");
            var detailDataObject = JsonConvert.DeserializeObject<DetailData>(jsonResponse);
            return detailDataObject;
        }
        
        public static async Task<List<MapData>> GetMapDataList(double lat, double lon)
        {
            var radiusData = await GetRadiusData(lat,lon);
            var mapDataList = new List<MapData>();
            foreach(RadiusData val in radiusData)
            {
                var tmp = await GetDetailData(val.xid);
                mapDataList.Add(new MapData(val.name,tmp.wikipedia,tmp.image));
            }
            return mapDataList;
        }
    }
}
