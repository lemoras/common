using Lemoras.Api.ServiceDiscovery;
using Lemoras.Api.Utils;
using Lemoras.Api.Filter;
using Lemoras.Domain.Parts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Lemoras.Api
{
    public abstract class Startup
    {
        internal protected string _serviceDbConnection;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _serviceDbConnection = Configuration.GetConnectionString("ServiceDbConnection");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            ConfigureConsul(services);
                        
            services.AddMvcCore().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CustomResolver 
                { 
                    NamingStrategy = new CamelCaseNamingStrategy() 
                };
            });

            services.AddSingleton<ISecretKeyProvider, SecretKeyProvider>();

            services.AddScoped<AuthorizationAttribute>();
            services.AddControllers();            
            services.AddHttpContextAccessor();

            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped(typeof(IApplicationContext<>), typeof(ApplicationContext<>));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
        
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<Middleware>();
            app.UseAuthentication();

            app.UseCors("AllowMyOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureConsul(IServiceCollection services)
        {
            var serviceConfig = Configuration.GetServiceConfig();

            services.RegisterConsulServices(serviceConfig);
        }
    }
}
