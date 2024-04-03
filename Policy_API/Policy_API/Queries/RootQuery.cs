using GraphQL;
using GraphQL.Types;
using Policy_API.Repository;

namespace Policy_API.Queries
{
    public class RootQuery : ObjectGraphType
    {

        public RootQuery(IVehicleRepo vehicleRepo,
            IPolicyHolderRepo policyHolderRepo,
            IPolicyRepo policyRepo,
            IAddressRepo addressRepo)
        {

            //all vehicles
            Field<ListGraphType<VehicleGQLType>>(
            "vehicles",
                    resolve: context => vehicleRepo.GetAllVehicles());



            //get vehicle by id
            Field<VehicleGQLType>(
               "vehicle",
               arguments: new QueryArguments(new
               QueryArgument<StringGraphType>
               { Name = "registrationNo" }),
               resolve: context => vehicleRepo
               .GetVehicleByRegNo(context.GetArgument<string>("registrationNo"))

               );


            Field<ListGraphType<PolicyHolderGQLType>>(
                Name = "policyholders",
                resolve: context => policyHolderRepo.GetAllPolicyHolders()

                );

            Field<PolicyHolderGQLType>(
                Name = "policyholder",
                arguments: new QueryArguments(new
                QueryArgument<StringGraphType>
                {
                    Name = "adharCardNo"
                }),
                resolve: context => policyHolderRepo
                .GetPolicyHolderById(context.GetArgument<string>("adharCardNo")

                ));

            Field< ListGraphType<PolicyGQLType>>(
                Name = "polices",
                resolve: context => policyRepo.GetAllPolicies());

            Field<PolicyGQLType>(
                Name = "policy",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "policyNo"
                }),
                resolve: context => policyRepo
                .GetPolicyByPolicyNo(context.GetArgument<long>("policyNo")
                ));

            Field<ListGraphType<AddressGQLType>>(
              Name = "addresses",
              resolve: context => addressRepo.GetAllAddress()
              );

            Field<AddressGQLType>(
               Name = "address",
               arguments: new QueryArguments(
                new QueryArgument<StringGraphType>
                {
                    Name = "aadharNo",
                },
                new QueryArgument<StringGraphType>
                {
                    Name = "doorNo",
                },
                new QueryArgument<StringGraphType>
                {
                    Name = "streetName",
                }

                ),
               resolve: context => addressRepo.GetAddressByAddressId(
                   context.GetArgument<string>("aadharNo"),
                   context.GetArgument<string>("doorNo"),
                   context.GetArgument<string>("streetName")
                   ));

        }

    }
}
