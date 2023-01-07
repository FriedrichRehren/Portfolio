using Microsoft.EntityFrameworkCore;
using Portfolio.Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Services

builder.Services.AddCors(options =>
{
    //options.AddPolicy(name: "angularDev", builder => builder.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyMethod());
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddDbContext<PortfolioContext>(dbOptions =>
{
    dbOptions.UseInMemoryDatabase("PortfolioDB");
    dbOptions.EnableSensitiveDataLogging(); //ToDo DEV
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion Services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

#pragma warning disable CS8604
    DbInitializer.Initialize(app.Services.CreateScope().ServiceProvider.GetService<PortfolioContext>());
#pragma warning restore CS8604
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.UseSpa(spa =>
{
    // To learn more about options for serving an Angular SPA from ASP.NET Core,
    // see https://go.microsoft.com/fwlink/?linkid=864501

    spa.Options.SourcePath = @"..\frontend\";

    if (app.Environment.IsDevelopment())
    {
        spa.Options.DevServerPort = 4200;
        //spa.UseAngularCliServer(npmScript: "start");
    }
});

app.Run();