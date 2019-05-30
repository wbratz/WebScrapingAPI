using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebScrapingAPI.Models;

namespace WebScrapingAPI.Utilities.Helpers
{
    public class SubPostHelper
    {
        private static HttpClient client = new HttpClient();

        public async Task<List<SubTopPosts>> LoadWebPage(List<Subs> subList)
        {           
            var SubTopPostsList = new List<SubTopPosts>();
            foreach (var sub in subList)
            {
                List<string> postList = await ParseWebPage(sub);

                SubTopPostsList.Add(new SubTopPosts { SubName = sub.SubTitle, TopPosts = postList });
            }

            return SubTopPostsList;
        }

        private static async Task<List<string>> ParseWebPage(Subs sub)
        {
            var response = await client.GetAsync("http://reddit.com/r/" + sub.Url);
            var pageContents = await response.Content.ReadAsStringAsync();
            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(pageContents);

            var postText = pageDocument.DocumentNode.SelectNodes("(//h2[contains(@class, 'yk4f6w-0')])");

            var postList = new List<string>();

            foreach (var post in postText)
            {
                postList.Add(HttpUtility.HtmlDecode(post.InnerText));
            }

            return postList;
        }
    }
}
