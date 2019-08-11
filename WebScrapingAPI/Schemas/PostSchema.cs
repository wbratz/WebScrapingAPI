using GraphQL;
using GraphQL.Types;
using WebScrapingAPI.Queries;

namespace WebScrapingAPI.Schemas
{
    public class PostSchema : Schema
    {
        public PostSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<PostQuery>();
        }
    }
}
