using GraphQL.Types;

namespace Policy_API.Mutations
{
    public class PolicyGQLInputTypes : InputObjectGraphType
    {
        public PolicyGQLInputTypes()
        {
            Name = "PolicyInput";
            Field<NonNullGraphType<LongGraphType>>("PolicyNo");
            Field<NonNullGraphType<StringGraphType>>("PolicyName");
            Field<NonNullGraphType<DateTimeGraphType>>("FromDate");
            Field<NonNullGraphType<DateTimeGraphType>>("ToDate");
            Field<NonNullGraphType<LongGraphType>>("InsuredAmount");
            Field<NonNullGraphType<StringGraphType>>("AadharCardNo");
            Field<NonNullGraphType<StringGraphType>>("RegistrationNo");
        }
    }
}
