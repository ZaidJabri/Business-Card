using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
