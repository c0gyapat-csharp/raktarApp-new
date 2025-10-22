using Microsoft.EntityFrameworkCore;
using RaktarAppBackend.Context;
using RaktarAppBackend.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBackend();

var app = builder.Build();

app.UseCors(BackendExtension.CorsPolicyName);


using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppSqliteDbContext>();
    dbContext.Database.EnsureCreated();

    dbContext.Database.ExecuteSqlRaw(@"
       CREATE TABLE IF NOT EXISTS Addresses (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Country TEXT NOT NULL,
            Region TEXT NOT NULL,
            PostCode INTEGER NOT NULL,
            City TEXT NOT NULL,
            Address TEXT NOT NULL
        );
    ");
}

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


