using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamGameListAppUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppList.GetAllApps();
            // Connect to the API and get all of the apps.

            // For each app check if it exists in the database already

            // If it doesn't, add to list to check back later

            // Loop through list and go and retrieve more information until hit API call limit

            // Once hit API call limit wait for 2 minutes and try again until we are up and running again

            // Display progress to the user
        }
    }
}
