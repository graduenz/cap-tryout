using CapTryout.Domain;
using CapTryout.Domain.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CapTryout.IoC;
public static class DependencyInjectionBootstrapper
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DbContext"))
        );

        services.AddCap(x =>
        {
            x.UseEntityFramework<AppDbContext>();
            x.UseRabbitMQ(o => {
                o.ConnectionFactoryOptions = x => x.Uri = new Uri(configuration.GetConnectionString("RabbitMQ"));
            });
        });
    }
}
