using System.Reflection;
using Microsoft.OpenApi.Models;
using SaveLater.Application;
using SaveLater.Persistence.EF;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); //test
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {   Version = "v1",
        Title = "Save Later API",

    });
   
});

builder.Services.AddSaveLaterApplication();
builder.Services.AddSaveLaterPersistenceServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod() //for now everything can get access
        );

});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("Open");
app.UseSwagger();
app.UseSwaggerUI();
app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();

    }
);



//app.MapGet("/", () => "Hello World!");

app.Run();
