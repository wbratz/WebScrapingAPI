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
        [Route("data/TopPost/{sub}")]
        public async Task<List<TopPostsBySubDTO>> GetTopPostsBySub(int sub)
        {
            return await _webScrapingRepository.GetTopPostsBySub(sub);
        }

        [HttpGet]
        [Route("data/TopUpvote/{sub}")]
        public async Task<List<TopUpvotesDTO>> GetTopUpvotesBySub(int sub)
        {
            return await _webScrapingRepository.GetTopUpvotesBySub(sub);
        }

        [HttpGet]
        [Route("data/TopScraped/{sub}")]
        public async Task<List<TopScrapedDTO>> GetMostScrapedBySub(int sub)
        {
            return await _webScrapingRepository.GetTopScrapedBySub(sub);
        }

        [HttpGet]
        [Route("data/TopPostAllTime")]
        public async Task<TopUpvotesDTO> GetTopUpVotedAllTime()
        {
            return await _webScrapingRepository.GetTopUpvotedAllTime();
        }

        [HttpGet]
        [Route("data/TopScrapedAllTime")]
        public async Task<TopScrapedDTO> GetMostScrapedAllTime()
        {
            return await _webScrapingRepository.GetTopScrapedAllTime();
        }

        [HttpGet]
        [Route("subs")]
        public async Task<List<string>> GetSubs()
        {
            return await _webScrapingRepository.GetSubs();
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
