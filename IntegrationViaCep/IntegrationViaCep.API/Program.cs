using IntegrationViaCep.Core.InfraCrossCutting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Initilize services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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
// Add AWS Lambda support.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

//Initialize inject dependency services.
ConfigurationIoc.Register(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
