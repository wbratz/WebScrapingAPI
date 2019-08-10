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
    }
}
