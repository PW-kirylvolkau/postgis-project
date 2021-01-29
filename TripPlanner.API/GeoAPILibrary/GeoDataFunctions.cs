using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GeoAPILibrary
{    
    public static class GeoDataFunctions
    {
        public static string apiKey = "af613013187a4565b6e1934040b5da3f";

        public static async Task<string> getApi(string query)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.geoapify.com/v1/geocode"+query;
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
        public static async Task<GeoDetailData> GetDetailData(string address)
        {
            string result = await getApi("/autocomplete?text="+address+"&limit=5&apiKey="+apiKey);
            var deserialized = JsonConvert.DeserializeObject<GeoDetailData>(result);
            return deserialized;
        }

        public static async Task<GeoDetailData> GetDetailData(double lat, double lon)
        {
            string result = await getApi("/reverse?lat="+lat+"&lon="+lon+"&lang=en&apiKey="+apiKey);
            var deserialized = JsonConvert.DeserializeObject<GeoDetailData>(result);
            return deserialized;
        }

        public static async Task<List<GeoData>> GetDataList(string address)
        {
            var detailData = await GetDetailData(address);
            var dataList = new List<GeoData>();
            foreach(var obj in detailData.features)
            {
                dataList.Add(new GeoData(obj.properties));
            }
            return dataList;
        }
        
        public static async Task<string> GetAddressFromCoords(double lat, double lon)
        {
            var detailData = await GetDetailData(lat, lon);
            var dataList = new List<GeoData>();
            foreach(var obj in detailData.features)
            {
                dataList.Add(new GeoData(obj.properties));
            }
            return dataList[0].Address;
        }

        public static async Task<Coordinates> GetCoordsFromAddress(string address)
        {
            var dataList = await GetDataList(address);
            return dataList[0].Coords;
        }
        public static async Task<List<object>> GetAddressList(string address)
        {
            var dataList = await GetDataList(address);
            var addressList = new List<object>();
            foreach(var obj in dataList)
            {
                addressList.Add(new
                {
                    address = obj.Address,
                    coordinates = new
                    {
                        lat = obj.Coords.Lat,
                        lng = obj.Coords.Lon
                    }
                });
            }
            return addressList;
        }
    }
}