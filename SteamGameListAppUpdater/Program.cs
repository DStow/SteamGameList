using System;
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

            int counter = 0;

            foreach (GetAppListApp steamApp in apiApps)
            {
                //if(uploadCount> 10)
                //{
                //    break;
                //}

                // Attempt to get from database
                SteamApp existingApp = dbApps.Where(x => x.AppId == steamApp.AppId).FirstOrDefault();

                if (existingApp == null)
                {
                    // Add
                    WriteLine(string.Format("Missing {0}: {1}", steamApp.AppId, steamApp.Name), 0);
                    SteamApp newSteamApp = SteamApp.CreateSteamApp(steamApp.AppId, steamApp.Name);

                    SteamApp.UpdateSteamAppReleaseDate(newSteamApp.SteamAppId, GetAppReleaseDate.GetAppReleaseDates(newSteamApp.AppId));
                }
                else if (existingApp.ReleaseDate == null)
                {
                    WriteLine(string.Format("No Release Date {0}: {1}", steamApp.AppId, steamApp.Name), 0);

                    // Get the release date
                    SteamApp.UpdateSteamAppReleaseDate(existingApp.SteamAppId, GetAppReleaseDate.GetAppReleaseDates(existingApp.AppId));
                }
                else
                {
                    WriteLine(string.Format("Found {0}: {1}", steamApp.AppId, steamApp.Name), 0);
                }

                counter++;

                WriteLine(counter + " / " + apiApps.Count, 2);
            }
        }

        static void WriteLine(string message, int lineIndex)
        {
            Console.SetCursorPosition(0, lineIndex);

            string clear = "";

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                clear += " ";
            }


            Console.Write(clear);
            Console.SetCursorPosition(0, lineIndex);

            Console.Write(message);
        }
    }
}
