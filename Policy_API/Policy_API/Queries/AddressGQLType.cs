using GraphQL.Types;
using Policy_API.Models;

namespace Policy_API.Queries
{
    public class AddressGQLType : ObjectGraphType<Address>
    {
        public AddressGQLType()
        {
            Name = "Address";
            Field(_ => _.AddressId).Description("Address ID");
            Field(_ => _.DoorNo).Description("Door Number");
            Field(_ => _.streetName).Description("Street");
            Field(_ => _.City).Description("City");
            Field(_ => _.State).Description("State");
            Field(_ => _.Country).Description("Country");
            Field(_ => _.Pincode).Description("Pincode");
            Field(_ => _.AdharCardNo).Description("Aadhar Card No");
        }
    }
}
