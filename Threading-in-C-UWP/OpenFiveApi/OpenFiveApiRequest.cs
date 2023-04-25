using Microsoft.Data.Sqlite;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using Windows.Storage;

namespace Threading_in_C_UWP.OpenFiveApi
{
    public class OpenFiveApiRequest
    {
        //public static SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Windows.ApplicationModel.Package.Current.InstalledLocation.Path.Replace("bin\\Debug", "Datasets\\DungeonDB.mdf;Integrated Security=True"));
        public static SqliteConnection con = new SqliteConnection($"Filename={Path.Combine(ApplicationData.Current.LocalFolder.Path, "userdData.db")}");
        private readonly OpenFiveApiUrlBuilder urlBuilder;

        public OpenFiveApiRequest()
        {
            urlBuilder = new OpenFiveApiUrlBuilder();

            //ApplicationData.Current.LocalFolder.CreateFileAsync("userData.db", CreationCollisionOption.OpenIfExists);
            //string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "userdData.db");
            //con = new SqliteConnection($"Filename={pathToDB}");
            //Debug.WriteLine("constructur");
        }

        public string GetEndpointUrl(string endpoint)
        {
            return urlBuilder.returnOpenFiveApiURl(endpoint);
        }

        public string MakeOpenFiveApiRequest(string endpoint, int? page = null, int? cr = null, string rarity = null)
        {
            string url = GetEndpointUrl(endpoint);

            // Checks if page parameter is given
            if (page != null)
            {
                url += $"?page={page}";
            }

            if (endpoint == "monsters" && cr.HasValue)
            {
                int crConstrained = Math.Min(Math.Max((int)cr, 0), 30);
                url += $"?challenge_rating={crConstrained}";
            }

            if (endpoint == "magicitems" && rarity != null)
            {
                url += $"?rarity={rarity}";
            }

            using (var client = new WebClient())
            {
                try
                {
                    return client.DownloadString(url);
                }
                catch (WebException ex)
                {
                    if (ex.Response is HttpWebResponse response && response.StatusCode == HttpStatusCode.NotFound)
                    {
                        // handle 404 error
                        Console.WriteLine("Resource not found: " + url);
                    }
                    else
                    {
                        Console.WriteLine("WebException occurred: " + ex.Message);
                    }

                    return null;
                }
            }
        }
    }
}
