using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GeoAPILibrary
{
    static class apiKey
    {
        public static string value = "47f523a46b944b47862e39509a7833a9";
    }
    public static class GeoAPIFunctions
    {
        public static async Task<List<GeoAPIEntity>> GetEntityList(string address)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.geoapify.com/v1/geocode/autocomplete?text="+address+"&limit=5&apiKey="+apiKey.value;
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            Root deserialized = JsonConvert.DeserializeObject<Root>(result);
            var entityList = new List<GeoAPIEntity>();
            foreach(var feats in deserialized.features)
            {
                entityList.Add(new GeoAPIEntity(feats.properties));
            }
            return entityList;

        }

        public static async Task<List<GeoAPIEntity>> GetEntityList(double lat, double lon)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.geoapify.com/v1/geocode/reverse?lat="+lat+"&lon="+lon+"&lang=en&apiKey="+apiKey.value;
            HttpResponseMessage response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            Root deserialized = JsonConvert.DeserializeObject<Root>(result);
            var entityList = new List<GeoAPIEntity>();
            foreach(var feats in deserialized.features)
            {
                entityList.Add(new GeoAPIEntity(feats.properties));
            }
            return entityList;
        }
        
        public static async Task<string> GetAddress(double lat, double lon)
        {
            var entityList = await GetEntityList(lat, lon);
            return entityList[0].Address;
        }

        public static async Task<Coordinates> GetCoordinates(string address)
        {
            var entityList = await GetEntityList(address);
            return entityList[0].Coords;
        }
        public static async Task<List<string>> GetAddressList(string address)
        {
            var entityList = await GetEntityList(address);
            var addressList = new List<string>();
            foreach(var entity in entityList)
            {
                addressList.Add(entity.Address);
            }
            return addressList;
        }

    }
}