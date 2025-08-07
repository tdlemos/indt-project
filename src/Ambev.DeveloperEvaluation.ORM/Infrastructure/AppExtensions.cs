using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Indt.Proposta.ORM.Infrastructure;

public static class AppExtensions
{
    public static void MigrateDb(this IHost app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dataContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();
            
            dataContext.Database.EnsureCreated();

            dataContext.Database.Migrate();
        }
    }
}
