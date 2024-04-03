using GraphQL.Types;
using Policy_API.Models;

namespace Policy_API.Mutations
{
    public class PolicyHolderGQLInputTypes : InputObjectGraphType
    {
        public PolicyHolderGQLInputTypes()
        {
            Name = "PolicyHolderInput";
            Field<NonNullGraphType<StringGraphType>>("AadharCardNo");

            Field<NonNullGraphType<StringGraphType>>("DOB");
            Field<NonNullGraphType<StringGraphType>>("Email");
            Field<NonNullGraphType<LongGraphType>>("MobileNo");
            Field<NonNullGraphType<EnumerationGraphType<Gender>>>("Gender");

        }
    }
}
