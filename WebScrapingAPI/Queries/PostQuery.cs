using GraphQL.Types;
using WebScrapingAPI.GraphTypes;
using WebScrapingAPI.Repositories.Contracts;

namespace WebScrapingAPI.Queries
{
    public class PostQuery : ObjectGraphType
    {
        public PostQuery(IWebScrapingRepository repository)
        {
            Field<ListGraphType<PostType>>(
                "posts",
                resolve: context => repository.GetAllPosts()
                );
        }
    }
}
