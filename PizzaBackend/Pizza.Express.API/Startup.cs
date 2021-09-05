using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Pizza.Express.Context;
using Pizza.Express.Context.Interfaces;
using Pizza.Express.Shared.Security;
using Pizza.Express.Handler.Interfaces;
using Pizza.Express.Handler;

namespace Pizza.Express.API
{
    public class Startup
    {
        #region CONSTRUCTOR
        private IConfiguration Configuration { get; }
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region CONFIGURESERVICES
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region JWT
            // JWT Configuration
            var appSettingsSection = Configuration.GetSection("App");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            // Authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region USERROLES
            // Authorisation
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("Client", policy => policy.RequireRole("Client"));
            });
            #endregion

            #region EFCORE
            // EfCore
            services.AddDbContextPool<SqlContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppDB"));
            });
            #endregion

            #region SERVICES
            // Services & Context
            services.AddScoped<IGlobals, Globals>();
            services.AddHttpContextAccessor();
            services.AddScoped<ISecurityHandler, SecurityHandler>();
            services.AddScoped<ISecurityContext, SecurityContext>();
            #endregion

            #region CORS
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                        builder => builder.WithOrigins(appSettings.PortalUrlCors.Split(","))
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            #endregion

            services.AddControllers();
        }
        #endregion

        #region CONFIGURE
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
        #endregion
    }
}
