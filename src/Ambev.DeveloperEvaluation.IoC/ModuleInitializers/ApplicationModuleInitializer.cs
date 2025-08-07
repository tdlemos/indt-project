using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Security;

namespace Indt.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
    }
}