using GraphQL.Types;
using Policy_API.Models;

namespace Policy_API.Queries
{
    public class PolicyHolderGQLType : ObjectGraphType<PolicyHolder>
    {
        public PolicyHolderGQLType()
        {
            Name = "PolicyHolders";
            Field(_ => _.AadharCardNo).Description("Adharcard No");
            Field(_ => _.Name.FirstName).Description("Adharcard No");
            Field(_ => _.Name.LastName).Description("Adharcard No");
            Field(_ => _.Name.MiddleName).Description("Adharcard No");
            Field(_ => _.DOB).Description("Adharcard No");
            Field(_ => _.Email).Description("Adharcard No");
            Field(_ => _.MobileNo).Description("Adharcard No");
            Field<StringGraphType>("gender",
                resolve: context =>
                context.Source.Gender.ToString());





        }
    }
}
