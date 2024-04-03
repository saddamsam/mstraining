using GraphQL.Types;
using Policy_API.Mutations;
using Policy_API.Queries;


namespace Policy_API.Schemas
{
    public class PolicySchema : Schema
    {
        public PolicySchema(IServiceProvider serviceProvider)
        {
          Query = serviceProvider.GetRequiredService<RootQuery>();
          Mutation = serviceProvider.GetRequiredService<RootMutation>();

        }
    }
}