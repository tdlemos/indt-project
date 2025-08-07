using Microsoft.AspNetCore.Builder;

namespace Indt.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
