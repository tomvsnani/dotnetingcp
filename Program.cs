
using Google.Api;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.GoogleCloudLogging;
using System.Diagnostics;
using WebApplication1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

builder.Host.UseSerilog((ctx,t) => {
  
    t.MinimumLevel.Is(Serilog.Events.LogEventLevel.Debug);

    t.ReadFrom.Configuration(ctx.Configuration)   
     ;



});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();




/*builder.Services.AddDbContext<SQLContext>(options => options.UseMySQL(connectionString: builder.Configuration.GetConnectionString("Mysql")).LogTo(Console.Write));
*/
var app = builder.Build();









// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();




app.UseCors(options=>options.AllowAnyOrigin());


app.UseAuthorization();

app.MapControllers();

app.Run();
