using SaveLater.Application;
using SaveLater.Persistence.EF;


var builder = WebApplication.CreateBuilder(args);

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

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();

    }
);



app.MapGet("/", () => "Hello World!");

app.Run();
