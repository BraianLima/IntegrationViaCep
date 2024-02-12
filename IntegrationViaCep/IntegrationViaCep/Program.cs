using IntegrationViaCep.Core.InfraCrossCutting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(opt =>
{
    //API doc
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Integration ViaCep API",
        Contact = new OpenApiContact
        {
            Name = "Braian Freitas de Lima",
            Email = "braianfreitasdelima@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/braian-freitas-de-lima-8968a2115/")

        },
        Description = "API integration with ViaCep",
        Version = "v1",
    });
});
string allowedOrigins = "_allowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: allowedOrigins,
        policy =>
        {
            policy.WithOrigins("https://integration-viacep.com", "https://integration-via-cep-front.vercel.app").AllowAnyHeader().AllowAnyMethod();
        });

});

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

//Initialize inject dependency services.
ConfigurationIoc.Register(builder.Services);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors(allowedOrigins);
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("./swagger", permanent: false);
    return Task.FromResult(0);
});
app.Run();
