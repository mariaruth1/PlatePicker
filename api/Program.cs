using System.Data;
using core.services;
using core.services.interfaces;
using infrastructure.repository;
using infrastructure.repository.interfaces;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("PP_CONNECTION_STRING");

builder.Services.AddScoped<IDbConnection>(container =>
{
    var connection = new NpgsqlConnection(connectionString ?? throw new Exception("Connection string cannot be null"));
    connection.Open();
    return connection;
});

builder.Services.AddScoped<IPlateRepository, PlateRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPlateService, PlateService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();