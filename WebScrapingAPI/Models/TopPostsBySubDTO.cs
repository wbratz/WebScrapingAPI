using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScrapingAPI.Models
{
    public class TopPostsBySubDTO
    {
        public string SubName { get; set; }
        public string PostTitle { get; set; }
        public string HighestUpvotesRecorded { get; set; }
        public int NumberOfTimesScraped { get; set; }
    }
}
