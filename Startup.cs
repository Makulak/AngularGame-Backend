using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CardsGame.Database.MongoDb.Settings;
using Microsoft.Extensions.Options;
using CardsGame.Services.Interfaces;
using CardsGame.Services.Implementations;
using Microsoft.AspNetCore.SignalR;
using CardsGame.Hubs;
using PotatoServer;
using CardsGame.Database;
using Microsoft.EntityFrameworkCore;
using PotatoServer.Database.Models;

namespace CardsGame
{
    public class Startup : BaseStartup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSignalR(x => x.EnableDetailedErrors = true);

            services.AddDbContext<CardsGameDatabaseContext>(o => o.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.SetupIdentity<User, CardsGameDatabaseContext>(Configuration);

            services.Configure<MongoDbSettings>(_configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<IMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddSingleton<IWaitingRoomService, WaitingRoomService>();
            services.AddSingleton<IConnectionService, ConnectionService>();
            services.AddSingleton<IGameService, GameService>();

            services.AddSingleton<IUserIdProvider, EmailBasedUserIdProvider>();

            services.AddTransient<IMapperService, MapperService>();

            base.ConfigureServices(services);
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<PotatoHub>("/hub/potato");
            });

            base.Configure(app, env);
        }
    }
}
