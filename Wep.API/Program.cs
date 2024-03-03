using Application;
using Application.Abstractions;
using Application.Users.Commands;
using Application.Users.CommandHandlers;
using Domain.User;
using Infrastucture;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Infrastucture.Repositories.Client;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
try
{
    Log.Information("Starting web api");

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services
        .AddApplication()
        .AddInfrastucture();
    
    // Configuracion de la conexion a PostgreSQL Server
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
    
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IClientRepository, ClientRepository>();

    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUser).Assembly));

    builder.Host.UseSerilog();


    // configuracion de Identity
    builder.Services.AddIdentity<User, IdentityRole<UserId>>(options =>
    {
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Lockout.MaxFailedAccessAttempts = 5;
    })
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole<UserId>>()
                .AddEntityFrameworkStores<AppDbContext>();

    builder.Services.AddControllersWithViews();

    // Set lowercase for all my urls
    builder.Services.AddRouting(options => options.LowercaseUrls = true);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.UseSerilogRequestLogging();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
