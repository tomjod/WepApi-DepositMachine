using Application;
using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Infrastructure.Repositories.Clients;
using Domain.Entities.Users;
using Application.Users.Commands.CreateUser;
using Quartz;
using Infrastructure.BackgroundJobs;
using Infrastructure.Interceptors;
using MediatR;
using Application.Behaviors;
using FluentValidation;
using Infrastructure.Repositories.Deposits;
using Infrastructure.Repositories.BanknoteValidationModules;
using Infrastructure.Repositories.Machines;
using Domain;
using Application.Abstractions;
using Infrastructure.Services;

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

    builder.Services.AddSingleton<ConvertDomainEventsToOutboxMessagesInterceptor>();

    builder.Services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

    //builder.Services.AddQuartz(configure =>
    //{
    //    var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));

    //    configure
    //        .AddJob<ProcessOutboxMessagesJob>(jobKey)
    //        .AddTrigger(
    //            trigger =>
    //                trigger.ForJob(jobKey)
    //                    .WithSimpleSchedule(
    //                        schedule =>
    //                            schedule.WithIntervalInSeconds(100)
    //                                .RepeatForever()));

    //    configure.UseMicrosoftDependencyInjectionJobFactory();
    //});

    //builder.Services.AddQuartzHostedService();

    builder.Services.AddScoped<IApiKeyService, ApiKeyService>();
    builder.Services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
    builder.Services.AddScoped<IBranchRepository, BranchRepository>();
    builder.Services.AddScoped<IAddressRepository, AddressRepository>();
    builder.Services.AddScoped<IDepositMachineRepository, DepositMachineRepository>();
    builder.Services.AddScoped<IBanknoteValidationModuleRepository, BanknoteValidationModuleRepository>();
    builder.Services.AddScoped<IDepositRepository, DepositRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IClientRepository, ClientRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));

    builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

    //builder.Services.Decorate(typeof(INotificationHandler<>), typeof(IdempotentDomainEventHandler<>));
    
    builder.Host.UseSerilog();


    // configuracion de Identity
    builder.Services.AddIdentity<User, IdentityRole<UserId>>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.User.AllowedUserNameCharacters = "1234567890K";
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
