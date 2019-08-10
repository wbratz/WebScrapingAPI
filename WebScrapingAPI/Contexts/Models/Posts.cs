using System;
using System.Collections.Generic;

namespace WebScrapingAPI.Contexts.Models
{
    public partial class Posts
    {
        public int Id { get; set; }
        public int? SubId { get; set; }
        public string Title { get; set; }
        public string UpVotes { get; set; }

        public virtual Subs Sub { get; set; }
    }
}
