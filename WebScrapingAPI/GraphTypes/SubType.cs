using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScrapingAPI.Contexts.Models;

namespace WebScrapingAPI.GraphTypes
{
    public class SubType : ObjectGraphType<Subs>
    {
        public SubType()
        {
            Field(x => x.Id);
            Field(x => x.Name);            
        }
    }
}
