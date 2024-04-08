
using Google.Api;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApplication1.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseSerilog((ctx,t) => {
  
    t.MinimumLevel.Information();

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







app.UseHttpLogging();

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
