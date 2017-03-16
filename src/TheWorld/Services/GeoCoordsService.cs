using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TheWorld.Services
{
    public class GeoCoordsService
    {
        private IConfigurationRoot _config;
        private ILogger<GeoCoordsService> _logger;

        public  GeoCoordsService(ILogger<GeoCoordsService> logger,
            IConfigurationRoot config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<GeoCoordsResult> GetCoordsAsync(string name)
        {
            var result = new GeoCoordsResult()
            {
                Success = false,
                Message = "Failed to get coordinates"
            };

            // Get Longitude and Latitude from place name

            var encodedName = WebUtility.UrlEncode(name);

            // Set up for Google Maps
            var apiKey = _config["Keys:GoogleKeys"];
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={encodedName}&key={apiKey}";

            var client = new HttpClient();

            var json = await client.GetStringAsync(url);

            var results = JObject.Parse(json);
            var resources = results["results"][0];
            if(!results.HasValues)
            { 
                result.Message = $"could not find '{name}' as a location";
            }
            else
            {
                var confidence = (string)resources["geometry"]["location_type"];
                if (confidence == "TODO!!" )
                {
                    result.Message = $"Could not find a confident match for '{name}' as a coordinate point";
                }
                else
                {
                    result.Latitude = (double)resources["geometry"]["location"]["lat"];
                    result.Longitude = (double)resources["geometry"]["location"]["lng"];
                    result.Success = true;
                    result.Message = "Success";
                }
            }
            return result;
        }
    }
}
