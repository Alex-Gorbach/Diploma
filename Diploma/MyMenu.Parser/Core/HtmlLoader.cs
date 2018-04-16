using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        readonly string recipeUrl;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}{settings.Prefix}";
            recipeUrl= $"{settings.BaseUrl}";
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response!=null && response.StatusCode==HttpStatusCode.OK)
            {
                source =await response.Content.ReadAsStringAsync();
            }

            return source;
        }

        public async Task<string> GetRecipeByPageHref(string href)
        {
            var response = await client.GetAsync(href);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
