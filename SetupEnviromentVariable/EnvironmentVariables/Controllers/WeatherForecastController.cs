using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using RestSharp;
using Newtonsoft.Json;

namespace EnvironmentVariables.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public WeatherForecastController()
        {
        }

        [HttpGet]
        public async Task<IEnumerable<Root>> Get()
        {
            RestClient _httpClient =  new RestClient();

            var _baseUrl = Environment.GetEnvironmentVariable("URL A");

            var request = new RestRequest(_baseUrl, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            
            var response = await _httpClient.ExecuteAsync(request);

            var des = JsonConvert.DeserializeObject<List<Root>>(response.Content);


            //HttpPost
            var _baseUrl_B = Environment.GetEnvironmentVariable("URL B");
            var requestPost = new RestRequest(_baseUrl_B, Method.Post);
            requestPost.AddHeader("Content-Type", "application/json");

            var requestData = JsonConvert.SerializeObject(des);
            requestPost.AddParameter("application/json", requestData, ParameterType.RequestBody);


            //execute request
            var response_URL_B = await _httpClient.ExecuteAsync(requestPost);


            var deserializeData = JsonConvert.DeserializeObject<List<RootList>>(response_URL_B.Content);
            return (IEnumerable<Root>)deserializeData;

            //return (IEnumerable<Root>)deserializedBookingReq;
        }

        [HttpPost]
        public async Task<IEnumerable<Root>> PostAsync(IEnumerable<Root> root)
        {
            try
            {
                RestClient _httpClient = new RestClient();

                var _baseUrl = Environment.GetEnvironmentVariable("URL B");
                var request = new RestRequest(_baseUrl, Method.Post);
                request.AddHeader("Content-Type", "application/json");

                var bookingReqSerialize = JsonConvert.SerializeObject(root);
                request.AddParameter("application/json", bookingReqSerialize, ParameterType.RequestBody);


                //execute request
                var response = await _httpClient.ExecuteAsync(request);

                var deserializedBookingReq = JsonConvert.DeserializeObject<Root>(response.Content);
                return (IEnumerable<Root>)deserializedBookingReq;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
