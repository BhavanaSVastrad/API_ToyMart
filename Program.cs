using Microsoft.EntityFrameworkCore;
using API_Login_A_F.Models;

var builder = WebApplication.CreateBuilder(args);
//Configure the Sql Server Database ConnectionStrings
builder.Services.AddDbContext<fabstitchContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TEConnection")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Cross-Origin Resource Sharing - ACCESS THE API IN VARIOUS APPLICATIONS
builder.Services.AddCors(c => {
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
