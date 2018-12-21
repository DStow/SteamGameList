using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamGameListAppUpdater
{
    internal static class GetAppReleaseDate
    {
        public static DateTime GetAppReleaseDates(int appId)
        {
            RestClient client = new RestClient("http://store.steampowered.com/api");
            RestRequest request = new RestRequest("/appdetails", Method.GET);

            request.Parameters.Add(new Parameter("appids", appId, ParameterType.QueryString));

            IRestResponse response = client.Execute(request);

            dynamic appData = JsonConvert.DeserializeObject(response.Content);
            try
            {
                return appData[appId.ToString()]["data"]["release_date"].date;
            }
            catch
            {
                return new DateTime(1900, 01, 01);
            }
        }
    }
}
