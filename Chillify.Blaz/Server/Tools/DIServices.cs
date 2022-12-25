using Chillify.Dal.Data;
using Microsoft.EntityFrameworkCore;

namespace Chillify.Blaz.Server.Tools;

public static class DIServices
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<ChillContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

        return services;
    }
}
