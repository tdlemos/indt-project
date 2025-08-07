using HealthChecks;
using Indt.IoC;
using Indt.Proposta.Application;
using Indt.Proposta.ORM;
using Indt.Proposta.WebApi.Middleware;
using Logging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Validation;

namespace Indt.Proposta.WebApi;

public class Program
{
    public static void Main(string[] args)
    {

        Log.Information("Starting web application");

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.AddDefaultLogging();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.AddBasicHealthChecks();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<DefaultContext>(opt => opt.UseInMemoryDatabase("Proposta"));

        builder.RegisterDependencies();

        builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        });

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        var app = builder.Build();
        app.UseMiddleware<ValidationExceptionMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseBasicHealthChecks();

        app.MapControllers();

        //app.MigrateDb();

        app.Run();
    }
}
