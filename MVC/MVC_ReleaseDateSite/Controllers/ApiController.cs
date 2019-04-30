using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MVC_ReleaseDateSite.Controllers
{
    public class ApiController : Controller
    {
        //Todo inject api keys with dependancy injection
        public JsonResult MovieSuggestion(string title) {
            // full url: http://www.omdbapi.com/?s=frozen&y=2015&apikey=649d5450
            string url = "http://www.omdbapi.com/";
            string urlParameters = $"?t={title}&y=2019&plot=full&apikey=649d5450";
            JObject json = ApiRequest(url, urlParameters);
            return new JsonResult(json);
        }

        public JsonResult GameSuggestion(string title) {
            string url = "https://api-v3.igdb.com/games";
            string urlParameters = $"";
            Dictionary<string, string> headers = new Dictionary<string, string> {
                { "user-key", "0e3fa6e9bc58a93eff50ed957a6c0957" }
            };
            var client = new RestClient(url + urlParameters);
            client.AddDefaultHeader("user-key", "0e3fa6e9bc58a93eff50ed957a6c0957");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddQueryParameter("search", title);
            request.AddQueryParameter("fields", "name, cover.*, summary");
            IRestResponse response = client.Execute(request);
            JToken json = JArray.Parse(response.Content).FirstOrDefault();
            return new JsonResult(json);
        }

        private JObject ApiRequest(string url, string urlParameters) {
            var client = new RestClient(url + urlParameters);
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            return JObject.Parse(response.Content);
        }
    }
}