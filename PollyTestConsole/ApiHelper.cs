using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PollyTestConsole
{
    public class ApiHelper
    {
        private static ApiHelper _instance;

        public static ApiHelper instance
        {
            get
            {
                if(_instance == null)
                    _instance = new ApiHelper();

                return _instance;
            }
        }

        public HttpClient AppClient { get; set; }

        private ApiHelper()
        {
            InitializeClient();
        }

        public void InitializeClient()
        {
            AppClient = new HttpClient();
            AppClient.DefaultRequestHeaders.Accept.Clear();
            AppClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
