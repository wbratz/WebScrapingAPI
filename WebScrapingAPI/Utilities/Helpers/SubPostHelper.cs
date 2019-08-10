using HtmlAgilityPack;
using System;
using System.Collections.Generic;
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
                var subTopPosts = await ParseWebPage(sub);

                SubTopPostsList.Add(subTopPosts);
            }

            return SubTopPostsList;
        }

        private static async Task<SubTopPosts> ParseWebPage(Subs sub)
        {
            var response = await client.GetAsync("http://reddit.com/r/" + sub.Url);
            var pageContents = await response.Content.ReadAsStringAsync();
            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(pageContents);
          
            var postText = pageDocument.DocumentNode.SelectNodes("(//h3[contains(@class, '_eYtD2XCVieq6emjKBH3m')])");
            var upvoteCount = pageDocument.DocumentNode.SelectNodes("(//div[contains(@class, '_1rZYMD_4xY3gRcSS3p8ODO _25IkBM0rRUqWX5ZojEMAFQ')])");
            
            if(postText != null && upvoteCount != null)
            {
                var postList = new List<Post>();

                var smallestUpperBound = Math.Min(postText.Count, upvoteCount.Count);

                for (var i = 0; i < smallestUpperBound; i++)
                {
                    postList.Add(new Post
                    {
                        Title = HttpUtility.HtmlDecode(postText[i].InnerText),
                        UpVotes = HttpUtility.HtmlDecode(upvoteCount[i].InnerText)
                    });
                }

                var subTopPosts = new SubTopPosts
                {
                    SubName = sub.SubTitle,
                    TopPosts = postList
                };

                return subTopPosts;
            }
            else
            {
                throw new Exception("Data scraper has encountered an error, likely caused by class name changes on specified text.");
            };
        }
    }
}
