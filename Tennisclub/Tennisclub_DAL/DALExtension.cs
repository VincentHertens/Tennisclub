using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tennisclub_DAL.Repositories.GameRepositories;
using Tennisclub_DAL.Repositories.GameResultRepositories;
using Tennisclub_DAL.Repositories.GenderRepositories;
using Tennisclub_DAL.Repositories.LeagueRepositories;
using Tennisclub_DAL.Repositories.MemberFineRepositories;
using Tennisclub_DAL.Repositories.MemberRepositories;
using Tennisclub_DAL.Repositories.MemberRoleRepositories;
using Tennisclub_DAL.Repositories.RoleRepositories;

namespace Tennisclub_DAL
{
    public static class DALExtension
    { 
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<IMemberRoleRepository, MemberRoleRepository>();
            services.AddTransient<IGameResultRepository, GameResultRepository>();
            services.AddTransient<IMemberFineRepository, MemberFineRepository>();
            return services;
        }

        public static IServiceCollection AddTennisclubContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TennisclubContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
