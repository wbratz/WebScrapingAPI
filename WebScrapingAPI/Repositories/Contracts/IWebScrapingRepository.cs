using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScrapingAPI.Models;

namespace WebScrapingAPI.Repositories.Contracts
{
    public interface IWebScrapingRepository
    {
        Task<List<SubTopPosts>> ScrapeData();
        Task<bool> SaveTopPostsTodb();
        Task<List<TopPostsBySubDTO>> GetTopPostsBySub(int sub);
        Task<List<TopUpvotesDTO>> GetTopUpvotesBySub(int sub);
        Task<List<TopScrapedDTO>> GetTopScrapedBySub(int sub);
        Task<TopUpvotesDTO> GetLeastUpvotedBySub(int sub);
        Task<TopUpvotesDTO> GetTopUpvotedAllTime();
        Task<TopScrapedDTO> GetTopScrapedAllTime();
        Task<TopUpvotesDTO> GetLeastUpvotedAllTime();
        Task<List<string>> GetSubs();
    }
}
