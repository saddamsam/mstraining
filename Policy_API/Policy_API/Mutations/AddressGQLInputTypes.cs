using GraphQL.Types;

namespace Policy_API.Mutations
{
    public class AddressGQLInputTypes : InputObjectGraphType
    {
        public AddressGQLInputTypes()
        {
            Name = "addressInput";
            Field<NonNullGraphType<StringGraphType>>("doorNo");
            Field<NonNullGraphType<StringGraphType>>("streetName");
            Field<NonNullGraphType<StringGraphType>>("city");
            Field<NonNullGraphType<StringGraphType>>("state");
            Field<NonNullGraphType<StringGraphType>>("country");
            Field<NonNullGraphType<LongGraphType>>("pincode");
            Field<NonNullGraphType<StringGraphType>>("aadharNo");
        }
    }
}
