using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ComicProcessor
    {
        static List<ComicModel> comicCache = new List<ComicModel>();

        public static async Task<ComicModel> LoadComic(int comicNumber = 0)
        {
            string url = "";

            var result = GetComicFromCache(comicNumber);

            if (result != null)
                return result;

            if (comicNumber > 0)
                url = $"https://xkcd.com/{ comicNumber}/info.0.json";
            else
                url = "https://xkcd.com/info.0.json";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                    comicCache.Add(comic);
                    return comic;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }

        private static ComicModel GetComicFromCache(int comicNumber)
        {
            if(comicCache.Count > 0)
            {
                return comicCache.SingleOrDefault(c => c.Num == comicNumber);
            }

            return null;
        }

    }
}
