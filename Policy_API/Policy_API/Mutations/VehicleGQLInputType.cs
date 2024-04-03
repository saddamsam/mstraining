using GraphQL.Types;
using Policy_API.Models;

namespace Policy_API.Mutations
{
    public class VehicleGQLInputType : InputObjectGraphType
    {
        public VehicleGQLInputType()
        {
            Name = "VehicleInput";
            Field<NonNullGraphType<StringGraphType>>("RegistrationNo");
            Field<NonNullGraphType<StringGraphType>>("Maker");
            Field<NonNullGraphType<StringGraphType>>("DOR");
            Field<NonNullGraphType<StringGraphType>>("EngineNo");
            Field<NonNullGraphType<StringGraphType>>("ChassisNo");
            Field<NonNullGraphType<EnumerationGraphType<FuelType>>>("FuelType");
            Field<NonNullGraphType<StringGraphType>>("Color");
        }
    }
}
