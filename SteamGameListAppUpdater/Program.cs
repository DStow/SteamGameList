﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SteamGameListData.Models;

namespace SteamGameListAppUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GetAppListApp> apiApps = GetAppList.GetAllApps();
            List<SteamGameListData.Models.SteamApp> dbApps = SteamGameListData.Models.SteamApp.GetAllSteamApps();

            int uploadCount = 0;

            foreach(GetAppListApp steamApp in apiApps)
            {
                if(uploadCount> 10)
                {
                    break;
                }

                // Attempt to get from database
                SteamApp existingApp = dbApps.Where(x => x.AppId == steamApp.AppId).FirstOrDefault();

                if (existingApp == null)
                {
                    // Add
                    Console.WriteLine("Missing {0}: {1}", steamApp.AppId, steamApp.Name);
                    SteamApp.CreateSteamApp(steamApp.AppId, steamApp.Name);

                    uploadCount++;
                }
                else
                {
                    Console.WriteLine("Found {0}: {1}", steamApp.AppId, steamApp.Name);
                }
            }

            // Connect to the API and get all of the apps.

            // For each app check if it exists in the database already

            // If it doesn't, add to list to check back later

            // Loop through list and go and retrieve more information until hit API call limit

            // Once hit API call limit wait for 2 minutes and try again until we are up and running again

            // Display progress to the user
        }
    }
}
