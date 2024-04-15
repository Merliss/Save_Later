using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaveLater.Application.Contracts.Persistence;
using SaveLater.Persistence.EF.Repositories;

namespace SaveLater.Persistence.EF
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddSaveLaterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SaveLaterContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SaveLaterConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IPostRepository,PostRepository>();
            services.AddScoped<IEventsRepository,EventRepository>();

            return services;

        }
    }
}
