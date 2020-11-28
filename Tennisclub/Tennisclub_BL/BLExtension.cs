using Microsoft.Extensions.DependencyInjection;
using Tennisclub_BL.Services.GameResultServices;
using Tennisclub_BL.Services.GameServices;
using Tennisclub_BL.Services.GenderServices;
using Tennisclub_BL.Services.LeagueServices;
using Tennisclub_BL.Services.MemberFineServices;
using Tennisclub_BL.Services.MemberRoleServices;
using Tennisclub_BL.Services.MemberServices;
using Tennisclub_BL.Services.RoleServices;
using Tennisclub_DAL;

namespace Tennisclub_BL
{
    public static class BLExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<ILeagueService, LeagueService>();
            services.AddTransient<IMemberRoleService, MemberRoleService>();
            services.AddTransient<IGameResultService, GameResultService>();
            services.AddTransient<IMemberFineService, MemberFineService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddRepositories2();
            return services;
        }

        public static IServiceCollection RegisterContext(this IServiceCollection services, string connectionString)
        {
            services.AddTennisclubContext(connectionString);
            return services;
        }
    }
}
