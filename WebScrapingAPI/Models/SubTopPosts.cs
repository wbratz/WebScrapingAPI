using System.Collections.Generic;

namespace WebScrapingAPI.Models
{
    public class SubTopPosts
    {
        public string SubName { get; set; }
        public List<Post> TopPosts { get; set; }
    }
}
