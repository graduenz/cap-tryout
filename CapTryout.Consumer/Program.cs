using CapTryout.Consumer;
using CapTryout.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(cfg => cfg.AddJsonFile("hostsettings.json"))
    .ConfigureServices((ctx, services) =>
    {
        services.AddTransient<MealAddSub>();
        DependencyInjectionBootstrapper.ConfigureServices(services, ctx.Configuration);
    })
    .Build()
    .RunAsync();