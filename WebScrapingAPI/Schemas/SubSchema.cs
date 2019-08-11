using GraphQL;
using GraphQL.Types;
using WebScrapingAPI.Queries;

namespace WebScrapingAPI.Schemas
{
    public class SubSchema : Schema
    {
        public SubSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<SubQuery>();
        }

    }
}
