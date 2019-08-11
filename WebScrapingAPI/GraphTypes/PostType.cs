using GraphQL.Types;
using WebScrapingAPI.Contexts.Models;

namespace WebScrapingAPI.GraphTypes
{
    public class PostType : ObjectGraphType<Posts>
    {
        public PostType()
        {
            Field(x => x.Id);
            Field(x => x.SubId);
            Field(x => x.Title).Description("The title of the post");
            Field(x => x.UpVotes);
            Field(
                name: "Subs",
                type: typeof(SubType),
                resolve: context => context.Source.Sub);
        }
    }
}
