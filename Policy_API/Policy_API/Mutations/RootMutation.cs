using GraphQL;
using GraphQL.Types;
using Policy_API.Models;
using Policy_API.Queries;
using Policy_API.Repository;

namespace Policy_API.Mutations
{
    public class RootMutation : ObjectGraphType
    {

        public RootMutation(IVehicleRepo vehicleRepo,
            IPolicyHolderRepo policyHolderRepo,
            IPolicyRepo policyRepo,
            IAddressRepo addressRepo) {

            //Vehicles

            FieldAsync<VehicleGQLType>(
                Name = "addVehicle",
                arguments : new QueryArguments(
                new QueryArgument<VehicleGQLInputType>
                {
                    Name = "vehicleInput"
                }
                ),
                resolve : async context =>
                {
                    var result = await vehicleRepo
                    .AddVehicle(context.GetArgument<Vehicle>("vehicleInput"));
                    return result;
                }


                );

             FieldAsync<BooleanGraphType>(
                Name = "deleteVehicle",
                arguments : new QueryArguments(
                new QueryArgument<StringGraphType>
                {
                    Name = "registrationNo"
                }
                ),
                resolve : async context =>
                {
                    var result = await vehicleRepo
                    .DeleteVehicle(context.GetArgument<string>("registrationNo"));
                    return result;
                }


                );

            //Policy Holders

            FieldAsync<PolicyHolderGQLType>(
              Name = "addPolicyHolder",
              arguments: new QueryArguments(
              new QueryArgument<PolicyHolderGQLInputTypes>
              {
                  Name = "policyHolderInput"
              },
              new QueryArgument<FullNameGQLInputTypes>
              {
                  Name = "fullNameInput"
              }
              ),
              resolve: async context =>
              {
                  var policyData = context.GetArgument<PolicyHolder>("policyHolderInput");
                  policyData.Name = context.GetArgument<FullName>("fullNameInput");
                  var result = await policyHolderRepo
                  .AddPolicyHolder(policyData);
                  return result;
              }


              );

            FieldAsync<PolicyHolderGQLType>(
             Name = "updatePolicyHolder",
             arguments: new QueryArguments(
             new QueryArgument<StringGraphType>
             {
                 Name = "aadharCardNo"
             },
             new QueryArgument<StringGraphType>
             {
                 Name = "email"
             },
             new QueryArgument<LongGraphType>
             {
                 Name = "mobile"
             }
             ),
             resolve: async context =>
             {
                 var result = await policyHolderRepo
                 .UpdatePolicyHolder(context.GetArgument<string>("aadharCardNo"),
                 context.GetArgument<string>("email"),
                 context.GetArgument<long>("mobile")
                 );
                 return result;
             }


             );


            FieldAsync<BooleanGraphType>(
                Name="deletePolicyHolder",
                arguments: new QueryArguments(
                new QueryArgument<StringGraphType>
                {
                    Name= "aadharCardNo"
                    
                }
                ),
                resolve: async context =>
                {
                    var result = await policyHolderRepo.DeletePolicyHolder(
                    context.GetArgument<string>("aadharCardNo")
                    );

                    return result;
                }
               

                );

            //Policy

            FieldAsync<PolicyGQLType>(
                    Name = "addPolicy",
                    arguments: new QueryArguments(
                        new QueryArgument<PolicyGQLInputTypes> { Name = "policyInput" },
                        new QueryArgument<StringGraphType> { Name = "aadharCardNo" },
                        new QueryArgument<StringGraphType> { Name = "registrationNo" }
                    ),
                    resolve: async context =>
                    {
                        var result = await policyRepo.AddPolicy(
                            context.GetArgument<Policy>("policyInput"),
                            context.GetArgument<string>("aadharCardNo"),
                            context.GetArgument<string>("registrationNo")
                            );
                        return result;
                    }
                        
                );


            FieldAsync<BooleanGraphType>(
               Name = "deletePolicy",
               arguments: new QueryArguments(
               new QueryArgument<LongGraphType>
               {
                   Name = "policyNo"

               }
               ),
               resolve: async context =>
               {
                   var result = await policyRepo.DeletePolicy(
                   context.GetArgument<long>("policyNo")
                   );

                   return result;
               }


               );


            //Address

            FieldAsync<AddressGQLType>(
                Name="addAddress",
                arguments: new QueryArguments(
                        new QueryArgument<AddressGQLInputTypes> { Name = "addressInput"},
                        new QueryArgument<StringGraphType> { Name = "aadharNo"}
                    ),
                resolve : async context => {
                    var result = await addressRepo.AddAddress(context.GetArgument<Address>("addressInput"), context.GetArgument<string>("aadharNo"));
                    return result;  
                }
                );


            FieldAsync<AddressGQLType>(
                Name = "updateAddress",
                arguments: new QueryArguments(
                        new QueryArgument<AddressGQLInputTypes> { Name = "addressInput" },
                        new QueryArgument<StringGraphType> { Name = "aadharNo" },
                        new QueryArgument<StringGraphType> { Name = "oldDoorNo" },
                        new QueryArgument<StringGraphType> { Name = "oldStreetName" }

                    ),
                resolve: async context => {
                    var result = await addressRepo.UpdateAddress(context.GetArgument<Address>("addressInput"), context.GetArgument<string>("aadharNo"), context.GetArgument<string>("oldDoorNo"), context.GetArgument<string>("oldStreetName"));
                    return result;
                }
                );



            FieldAsync<BooleanGraphType>(
               Name = "deleteAddress",
               arguments: new QueryArguments(
               new QueryArgument<StringGraphType>
               {
                   Name = "aadharNo"

               },
               new QueryArgument<StringGraphType>
               {
                   Name = "doorNo"

               },
               new QueryArgument<StringGraphType>
               {
                   Name = "streetName"

               }
               ),
               resolve: async context =>
               {
                   var result = await addressRepo.DeleteAddress(
                   context.GetArgument<string>("aadharNo"),
                   context.GetArgument<string>("doorNo"),
                   context.GetArgument<string>("streetName")
                   );

                   return result;
               }


               );


        }

    }
}
