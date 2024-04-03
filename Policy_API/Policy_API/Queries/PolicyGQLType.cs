using GraphQL.Types;
using Policy_API.Models;

namespace Policy_API.Queries
{
    public class PolicyGQLType : ObjectGraphType<Policy>
    {
        public PolicyGQLType() {

            Name = "Policy";
            Field(_ => _.PolicyNo).Description("Policy Number");
            Field(_ => _.PolicyName).Description("Policy Name");
            Field(_ => _.FromDate).Description("Policy Start Date");
            Field(_ => _.ToDate).Description("Policy End Date");
            Field(_ => _.InsuredAmount).Description("Insured Amount");
            Field(_ => _.AdharCardNo).Description("Aadhar Number");
            Field(_ => _.RegistrationNo).Description("Registration Number");
            //Field(_ => _.PolicyHolder.Name.FirstName).Description("First Name");
            Field<StringGraphType>("PolicyHolderFirstName",
                resolve : context => context.Source.PolicyHolder.Name.FirstName
                );
           // Field(_ => _.Vehicle.Color).Description("Vehcile Color");
            Field<StringGraphType>("VehicleColor",
                resolve: context => context.Source.Vehicle.Color
                );
        }
    }
}
