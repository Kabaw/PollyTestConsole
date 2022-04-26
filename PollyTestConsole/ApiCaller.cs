using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PollyTestConsole
{
    public class ApiCaller
    {
        public async Task<ExempleDataModel> LoadComic(int comicNumber = 0)
        {
            string url = "";

            if(comicNumber > 0)
            {
                url = $"https://xkcd.com/{ comicNumber }/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }

            using (HttpResponseMessage response = await ApiHelper.instance.AppClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ExempleDataModel model = await response.Content.ReadAsAsync<ExempleDataModel>();

                    return model;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
