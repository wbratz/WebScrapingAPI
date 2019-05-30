using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScrapingAPI.Utilities.Helpers
{
    public class SubListBuilder
    {
        public static List<Subs> BuildSubs()
        {
            var SubList = new List<Subs>()
            {
                {
                    new Subs { SubTitle = "Ask Reddit", Url = "askreddit" }
                },
                {
                    new Subs {SubTitle = "Brazilian Jiu Jitsu", Url = "bjj"}
                },
                {
                    new Subs {SubTitle = "Boxing", Url = "boxing"}
                },
                {
                    new Subs {SubTitle = "Dad Jokes", Url = "dadjokes"}
                },
                {
                    new Subs {SubTitle = "Fitness", Url = "fitness"}
                },
                {
                    new Subs {SubTitle = "gaming", Url = "Gaming"}
                },
                {
                    new Subs {SubTitle = "Mixed Martial Arts", Url = "mma"}
                },
                {
                    new Subs {SubTitle = "Anti Multi Level Marketing", Url = "antiMLM"}
                },
                {
                    new Subs {SubTitle = "Motorcycles", Url = "motorcycles"}
                },
                {
                    new Subs {SubTitle = "Muay Thai", Url = "MuayThai"}
                },
            };

            return SubList;
        }
    }
}
