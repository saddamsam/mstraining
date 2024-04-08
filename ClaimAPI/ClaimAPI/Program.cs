using ClaimAPI.Context;
using ClaimAPI.Repository;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

//For Policy DB
//IDictionary<string, object> result = new VaultConfiguration(configuration).GetSecrets(rootKey, url).Result;
SqlConnectionStringBuilder providerCs = new SqlConnectionStringBuilder();
//providerCs.UserID = result["username"].ToString();
//providerCs.Password = result["password"].ToString();
providerCs.UserID = "sa";
//providerCs.Password = "Saddam@123";
providerCs.Password = "123";
providerCs.DataSource = configuration["connn"];
//providerCs.DataSource = configuration["servername"];
providerCs.InitialCatalog = "ClaimDB"; //configuration["policydbname"]; //PolicyDB
providerCs.MultipleActiveResultSets = true;
providerCs.TrustServerCertificate = true;


builder.Services.AddDbContext<ClaimContext>(o => o.UseSqlServer(providerCs.ToString()));

builder.Services.AddTransient<IClaimDetailsRepo, ClaimDetailsRepo>();
builder.Services.AddTransient<IDriverAddressRepo, DriverAddressRepo>();
builder.Services.AddTransient<IDriverDetailsRepo, DriverDetailsRepo>();
builder.Services.AddTransient<ILicenseDetailsRepo, LicenseDetailsRepo>();
builder.Services.AddTransient<IFIRDetailsRepo, FIRDetailsRepo>();
builder.Services.AddTransient<IPolicyRepo, PolicyRepo>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "PolicyAPI", Version = "v1" });
});
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});
var policyName = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                             .WithOrigins("http://localhost:*", "")
                             //.WithOrigins("http://localhost:3000")
                             // specifying the allowed origin
                             // .WithMethods("GET") // defining the allowed HTTP method
                             .AllowAnyOrigin()
                             // .WithHeaders(HeaderNames.ContentType, "ApiKey")
                             .AllowAnyMethod()
                            .AllowAnyHeader(); // allowing any header to be sent
                      });
});




var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(policyName);


app.Run();
