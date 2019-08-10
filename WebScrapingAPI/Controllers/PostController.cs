using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScrapingAPI.Models;
using WebScrapingAPI.Repositories.Contracts;

namespace WebScrapingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IWebScrapingRepository _webScrapingRepository;

        public PostController(IWebScrapingRepository webScrapingRepository)
        {
            _webScrapingRepository = webScrapingRepository;
        }

        [HttpGet]
        public async Task<List<SubTopPosts>> Get()
        {
            return await _webScrapingRepository.ScrapeData();
        }

        [HttpGet]
        [Route("data/TopPostData/{sub}")]
        public async Task<List<TopPostsBySubDTO>> GetTopPostsBySub(int sub)
        {
            return await _webScrapingRepository.GetTopPostsBySub(sub);
        }

        [HttpGet]
        [Route("data/TopUpvoteData/{sub}")]
        public async Task<List<TopPostsBySubDTO>> GetTopUpvotesBySub(int sub)
        {
            return await _webScrapingRepository.GetTopPostsBySub(sub);
        }

        [HttpGet]
        [Route("data/TopScrapedData/{sub}")]
        public async Task<List<TopPostsBySubDTO>> GetMostScrapedBySub(int sub)
        {
            return await _webScrapingRepository.GetTopPostsBySub(sub);
        }

        [HttpGet]
        [Route("data/TopPostAllTime")]
        public async Task<List<TopPostsBySubDTO>> GetTopPostAllTime(int sub)
        {
            return await _webScrapingRepository.GetTopPostsBySub(sub);
        }

        [HttpGet]
        [Route("data/TopScrapedAllTime")]
        public async Task<List<TopPostsBySubDTO>> GetMostScrapedAllTime(int sub)
        {
            return await _webScrapingRepository.GetTopPostsBySub(sub);
        }

        [HttpPost("{yes}")]
        public async Task<bool> PostDatatodb(bool yes)
        {
            if (yes)
            {
                var success = await _webScrapingRepository.SaveTopPostsTodb();
                return success;
            }
            else
            {
                return false;
            }

        }

    }
}
