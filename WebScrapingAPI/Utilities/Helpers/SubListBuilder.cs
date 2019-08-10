using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScrapingAPI.Contexts;

namespace WebScrapingAPI.Utilities.Helpers
{
    public class SubListBuilder
    {
        private readonly WebscrapingdbContext _context;

        public SubListBuilder(WebscrapingdbContext context)
        {
            _context = context;
        }

        public async Task<List<Subs>> BuildSubs()
        {
            var subsList = new List<Subs>();
            var subsContext = await _context.Subs.ToListAsync();

            ConvertSubContextToDTO(subsList, subsContext);

            return subsList;
        }

        private static void ConvertSubContextToDTO(List<Subs> subsList, List<Contexts.Models.Subs> subsContext)
        {
            foreach (var sub in subsContext)
            {
                subsList.Add(new Subs
                {
                    SubTitle = sub.Name,
                    Url = sub.Url
                });
            }
        }
    }
}
