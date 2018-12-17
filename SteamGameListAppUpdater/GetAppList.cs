using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace SteamGameListAppUpdater
{
    internal static class GetAppList
    {
        public static List<GetAppListApp> GetAllApps()
        {
            List<GetAppListApp> results = new List<GetAppListApp>();

            RestClient client = new RestClient("http://api.steampowered.com");
            RestRequest request = new RestRequest("/ISteamApps/GetAppList/v0002/", Method.GET);

            request.Parameters.Add(new Parameter("key", ConfigurationManager.AppSettings["SteamApiKey"], ParameterType.QueryString));

            IRestResponse response = client.Execute(request);

            dynamic allAppData = JsonConvert.DeserializeObject(response.Content);

            foreach (var app in allAppData["applist"]["apps"])
            {
                GetAppListApp newApp = new GetAppListApp()
                {
                    AppId = app.appid,
                    Name = app.name
                };

                results.Add(newApp);
            }

            return results;
        }
    }

    internal class GetAppListApp
    {
        public int AppId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return AppId + ": " + Name;
        }
    }
}
