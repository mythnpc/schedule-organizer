using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ScheduleOrganizer.Services.Data;
using Microsoft.EntityFrameworkCore;
using ScheduleOrganizer.Services.Data.Abstract;
using ScheduleOrganizer.Services.Data.Repositories;
using ScheduleOrganizer.ViewModels.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ScheduleOrganizer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ScheduleOrganizerContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IDungeonAttendanceRepository, DungeonAttendanceRepository>();
            services.AddScoped<IHeroRepository, HeroRepository>();
            services.AddScoped<IPlayerHeroRepository, PlayerHeroRepository>();

            // Automapper Configuration
            AutoMapperConfiguration.Configure();

            services.AddMvc();

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.
            //corsBuilder.WithOrigins("http://localhost:56573"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("SiteCorsPolicy");


            app.UseMvc();
        }
    }
}
