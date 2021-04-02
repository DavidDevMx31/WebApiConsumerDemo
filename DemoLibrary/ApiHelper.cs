using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ApiHelper
    {
        //To have one instance for the whole app. We should open once per application.
        public static HttpClient ApiClient { get; set; }

        /// <summary>
        /// Initializes ApiClient cleaning previous headers and setting "json" as the expected response type
        /// </summary>
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
