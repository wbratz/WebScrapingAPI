using System;
using System.Collections.Generic;

namespace WebScrapingAPI.Contexts.Models
{
    public partial class Subs
    {
        public Subs()
        {
            Posts = new HashSet<Posts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}
