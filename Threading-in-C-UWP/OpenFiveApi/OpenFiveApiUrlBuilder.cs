using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading_in_C_UWP.OpenFiveApi
{
    internal class OpenFiveApiUrlBuilder
    {
        // Declaring the base URL used for the API calls
        private const string BaseUrl = "https://api.open5e.com/";

        // Setting up a dictionaryy for the endpoints
        private Dictionary<string, string> Endpoints = new Dictionary<string, string>
        {
            { "manifest", BaseUrl + "manifest/" },
            { "spells", BaseUrl + "spells/" },
            { "monsters", BaseUrl + "monsters/" },
            { "documents", BaseUrl + "documents/" },
            { "backgrounds", BaseUrl + "backgrounds/" },
            { "planes", BaseUrl + "planes/" },
            { "sections", BaseUrl + "sections/" },
            { "feats", BaseUrl + "feats/" },
            { "conditions", BaseUrl + "conditions/" },
            { "races", BaseUrl + "races/" },
            { "classes", BaseUrl + "classes/" },
            { "magicitems", BaseUrl + "magicitems/" },
            { "weapons", BaseUrl + "weapons/" },
            { "armor", BaseUrl + "armor/" },
            { "search", BaseUrl + "search/" }
        };

        // Method to get the URL corresponding to the endpoint
        public string returnOpenFiveApiURl(string endpoint)
        {
            if (Endpoints.TryGetValue(endpoint, out string url)) return url;
            else throw new ArgumentException($"Unsupported endpoint '{endpoint}'", nameof(endpoint));
        }
    }
}
