using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebScrapingAPI.Models;
using WebScrapingAPI.Utilities.Helpers;

namespace WebScrapingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapingController : ControllerBase
    {

        [HttpGet]
        public async Task<string> Get()
        {         
            var httpHelper = new SubPostHelper();
            var result = httpHelper.LoadWebPage(SubListBuilder.BuildSubs());
            var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(await result);
            return jsonResult;
        }

        // GET api/values/5
        [HttpGet("boats")]
        public ActionResult<string> GetBoats()
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
