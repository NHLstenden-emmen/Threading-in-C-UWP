using Microsoft.Data.Sqlite;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using Windows.Storage;

namespace Threading_in_C_UWP.OpenFiveApi
{
    public class OpenFiveApiRequest
    {
        public static SqliteConnection con = new SqliteConnection($"Filename={Path.Combine(ApplicationData.Current.LocalFolder.Path, "DungeonDB.db")}");
        private readonly OpenFiveApiUrlBuilder urlBuilder;

        public OpenFiveApiRequest()
        {
            urlBuilder = new OpenFiveApiUrlBuilder();
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
