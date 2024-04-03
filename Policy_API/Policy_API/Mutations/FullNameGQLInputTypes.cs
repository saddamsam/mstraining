using GraphQL.Types;

namespace Policy_API.Mutations
{
    public class FullNameGQLInputTypes : InputObjectGraphType
    {
        public FullNameGQLInputTypes()
        {
            Name = "FullNameInput";
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("middleName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
        }
    }
}
