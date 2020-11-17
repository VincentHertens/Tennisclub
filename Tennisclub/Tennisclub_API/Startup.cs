using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tennisclub_Business_Layer.Services;
using Tennisclub_Data_Layer;
using Tennisclub_Data_Layer.Data;
using Tennisclub_Mapping.Mapping;

namespace Tennisclub_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddDbContext<TennisclubContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("TennisclubConnection")));

            services.AddControllers();
            services.AddAutoMapper(typeof(GameResultsProfile),
                typeof(GamesProfile),
                typeof(GendersProfile),
                typeof(LeaguesProfile),
                typeof(MemberFinesProfile),
                typeof(MemberRolesProfile),
                typeof(MembersProfile),
                typeof(RolesProfile));

            //Add services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ILeagueService, LeagueService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IMemberRoleService, MemberRoleService>();
            services.AddTransient<IGameResultService, GameResultService>();
            services.AddTransient<IMemberFineService, MemberFineService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
