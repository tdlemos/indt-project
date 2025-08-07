using Indt.Contratacao.Application.Refit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Indt.Contratacao.Application;

public static class Register
{
    public static IServiceCollection AddRefit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRefitClient<IPropostaApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration["Api:Proposta"]));

        return services;
    }
}
