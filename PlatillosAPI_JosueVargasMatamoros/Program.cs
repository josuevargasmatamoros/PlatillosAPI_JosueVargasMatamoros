using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PlatillosAPI_JosueVargasMatamoros.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var CnnStrBuilder = new SqlConnectionStringBuilder(
           builder.Configuration.GetConnectionString("CNNSTR")
           );

CnnStrBuilder.Password = "Josuevm1701";

string CnnStr = CnnStrBuilder.ConnectionString;

builder.Services.AddDbContext<PlatillosDbContext>(options => options.UseSqlServer(CnnStr));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();



app.UseAuthorization();

app.MapControllers();

app.Run();
