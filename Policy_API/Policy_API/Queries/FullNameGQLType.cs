using GraphQL.Types;
using Policy_API.Models;

namespace Policy_API.Queries
{
    public class FullNameGQLType : ObjectGraphType<FullName>
    {
        public FullNameGQLType()
        {
            Name = "FullName";
            Field(_ => _.FirstName).Description("First Name");
            Field(_ => _.LastName).Description("Last Name");
            Field(_ => _.MiddleName).Description("Middle Name");

        }
    }
}
