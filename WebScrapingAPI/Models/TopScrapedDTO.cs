using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScrapingAPI.Models
{
    public class TopScrapedDTO
    {
        public string SubName { get; set; }
        public string PostTitle { get; set; }
        public int NumberOfTimesScraped { get; set; }
    }
}
