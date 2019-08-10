using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScrapingAPI.Contexts;
using WebScrapingAPI.Contexts.Models;
using WebScrapingAPI.Models;
using WebScrapingAPI.Repositories.Contracts;
using WebScrapingAPI.Utilities.Helpers;

namespace WebScrapingAPI.Repositorites
{

    public class WebScrapingRepository :IWebScrapingRepository
    {
        private readonly WebscrapingdbContext _context;

        public WebScrapingRepository(WebscrapingdbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveTopPostsTodb()
        {
            var subTopPosts = await ScrapeData();

            var postlist = new List<Posts>();

            foreach(var sub in subTopPosts)
            {
                var subs = _context.Subs.Where(x => x.Name.Equals(sub.SubName)).SingleOrDefault();
                
                foreach(var post in sub.TopPosts)
                {
                    postlist.Add(new Posts
                    {
                        SubId = subs.Id,
                        Title = post.Title,
                        UpVotes = post.UpVotes
                    });
                }
            }

            try
            {
                await _context.Posts.AddRangeAsync(postlist);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Error posting to db");
            }
        }

        public async Task<List<TopPostsBySubDTO>> GetTopPostsBySub(int sub)
        {
            var TopPostsBySub = await _context.Posts.Where(x => x.SubId == sub)
                .Include(x => x.Sub.Name)
                .Select(x => new { x.Sub.Name, x.Title, MaxUpvotes = x.UpVotes.Max() }).Distinct().ToListAsync();

            var postlist = new List<TopPostsBySubDTO>();

            foreach(var postInfo in TopPostsBySub)
            {
                postlist.Add(new TopPostsBySubDTO
                {
                    SubName = postInfo.Name,
                    PostTitle = postInfo.Title,
                    HighestUpvotesRecorded = postInfo.MaxUpvotes.ToString(),
                    NumberOfTimesScraped = _context.Posts.Where(x => x.Title.Equals(postInfo.Title)).Distinct().Count()
                });
            }

            return postlist;
        }

        public async Task<List<SubTopPosts>> ScrapeData()
        {
            var httpHelper = new SubPostHelper();
            var sublistBuilder = new SubListBuilder(_context);
            var result = await httpHelper.LoadWebPage(sublistBuilder.BuildSubs().Result);
            
            //var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(await result);
            return result;
        }
    }
}
