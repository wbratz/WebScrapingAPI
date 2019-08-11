using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScrapingAPI.GraphTypes;
using WebScrapingAPI.Repositories.Contracts;

namespace WebScrapingAPI.Queries
{
    public class SubQuery : ObjectGraphType
    {
        public SubQuery(IWebScrapingRepository repository)
        {
            Field<ListGraphType<SubType>>(
                "subs",
                resolve: context => repository.GetSubs()
                );
        }
    }
}
