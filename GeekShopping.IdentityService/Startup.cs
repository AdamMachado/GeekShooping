
using GeekShopping.IdentityService.Configuaration;
using GeekShopping.IdentityService.Model.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;




namespace GeekShoopping.IdentityService
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
            var connection = Configuration["MySQlConnection:MySQlConnectionString"];

            services.AddDbContext<MySQLContext>(options => options.
                UseMySql(connection,
                        new MySqlServerVersion(
                            new Version(8, 0, 33, 0))));

            services.AddIdentity<ApplicationUser,IdentityRole>()
                .AddEntityFrameworkStores<MySQLContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>

            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;

            }).AddInMemoryIdentityResources(
                IdentityConfiguration.IdentityResources)
                    .AddInMemoryClients(IdentityConfiguration.Clients)
                    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
                    .AddAspNetIdentity<ApplicationUser>();
            
            builder.AddDeveloperSigningCredential();


            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseRouting();
            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
