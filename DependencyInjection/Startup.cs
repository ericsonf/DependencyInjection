using DependencyInjection.Interfaces;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace DependencyInjection
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
            /*
             * Possibilidade de colocar todos os arquivos que precisam ser injetados dentro de um �nico arquivo, deixando o
             * código mais Clean.
             */
            //services.AddAppConfiguration();

            services.AddTransient<RandomService>();
            //services.AddScoped<RandomService>();
            //services.AddSingleton<RandomService>();

            services.TryAddEnumerable(new[]
            {
                ServiceDescriptor.Singleton<IMessage, HelloMessageService>(),
                ServiceDescriptor.Singleton<IMessage, ErrorMessageService>()
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<RandomMiddleware>();

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
