using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

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
        public async Task<List<dynamic>> Get()
        {
            RestClient _httpClient = new RestClient();

            //Http GET
            var _baseUrl = Environment.GetEnvironmentVariable("URL A");
            var request = new RestRequest(_baseUrl, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            //execute request GET
            var response = await _httpClient.ExecuteAsync(request);
            var des = JsonConvert.DeserializeObject<ICollection<object>>(response.Content);


            //Http Post
            var _baseUrl_B = Environment.GetEnvironmentVariable("URL B");
            var requestPost = new RestRequest(_baseUrl_B, Method.Post);
            requestPost.AddHeader("Content-Type", "application/json");
            var requestData = JsonConvert.SerializeObject(des);
            requestPost.AddParameter("application/json", requestData, ParameterType.RequestBody);
            //execute request POST
            var response_URL_B = await _httpClient.ExecuteAsync(requestPost);    
            

            var deserializeData = JsonConvert.DeserializeObject<ExpandoObject>(response_URL_B.Content);
            List<object> list = new List<object>();
            foreach (var item in deserializeData)
            {
                list.Add(item.Value);
            }
            return list;

        }

        //[HttpPost]
        //public async Task<IEnumerable<dynamic>> PostAsync(IEnumerable<dynamic> root)
        //{
        //    try
        //    {
        //        RestClient _httpClient = new RestClient();

        //        var _baseUrl = Environment.GetEnvironmentVariable("URL B");
        //        var request = new RestRequest(_baseUrl, Method.Post);
        //        request.AddHeader("Content-Type", "application/json");

        //        var bookingReqSerialize = JsonConvert.SerializeObject(root);
        //        request.AddParameter("application/json", bookingReqSerialize, ParameterType.RequestBody);


        //        //execute request
        //        var response = await _httpClient.ExecuteAsync(request);

        //        var deserialized = JsonConvert.DeserializeObject<dynamic>(response.Content);
        //        return (IEnumerable<dynamic>)deserialized;
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
    }
}
