using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Helpers;
using UserManagement.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiService();

builder.Services.AddDbContext<UserManagementContext>(options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"), builder => builder.MigrationsAssembly("UserManagement.Infrastructure"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
