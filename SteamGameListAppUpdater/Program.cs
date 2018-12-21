using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SteamGameListData.Models;

namespace SteamGameListAppUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GetAppListApp> apiApps = GetAppList.GetAllApps();
            List<SteamApp> dbApps = SteamGameListData.Models.SteamApp.GetAllSteamApps();

            int counter = 0;

            foreach (GetAppListApp steamApp in apiApps)
            {
                // Attempt to get from database
                SteamApp existingApp = dbApps.Where(x => x.AppId == steamApp.AppId).FirstOrDefault();

                if (existingApp == null)
                {
                    // Add
                    WriteLine(string.Format("Missing {0}: {1}", steamApp.AppId, steamApp.Name), 0);
                    SteamApp newSteamApp = SteamApp.CreateSteamApp(steamApp.AppId, steamApp.Name);

                    SteamApp.UpdateSteamAppReleaseDate(newSteamApp.AppId, GetAppDate(newSteamApp));
                }
                else if (existingApp.ReleaseDate == null)
                {
                    WriteLine(string.Format("No Release Date {0}: {1}", steamApp.AppId, steamApp.Name), 0);

                    // Get the release date
                    SteamApp.UpdateSteamAppReleaseDate(existingApp.SteamAppId, GetAppDate(existingApp));
                }
                else
                {
                    WriteLine(string.Format("Found {0}: {1}", steamApp.AppId, steamApp.Name), 0);
                }

                counter++;

                WriteLine(counter + " / " + apiApps.Count, 2);
            }
        }

        static DateTime GetAppDate(SteamApp steamApp)
        {
            try
            {
                return GetAppReleaseDate.GetAppReleaseDates(steamApp.AppId);
            }
            catch (ToManyAPIRequestsException)
            {
                WriteLine("To many Steam Requests!", 1);
                Thread.Sleep(5000);
                return GetAppDate(steamApp);
            }
        }

        static void WriteLine(string message, int lineIndex)
        {
            Console.WriteLine(message);
            //Console.SetCursorPosition(0, lineIndex);

            //string clear = "";

            //for (int i = 0; i < Console.WindowWidth; i++)
            //{
            //    clear += " ";
            //}


            //Console.Write(clear);
            //Console.SetCursorPosition(0, lineIndex);

            //Console.Write(message);
        }
    }
}
