using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Gruppeoppgave1.DAL;
using Gruppeoppgave1.model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Stripe;

namespace Gruppeoppgave1
{
    public class Startup
    {
        public Startup(IConfiguration configuraton)
        {
            _config = configuraton;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // services.AddDbContext<KundeDB>(options =>
            //            options.UseSqlite("Data Source=Kunde.db"));

            services.AddDbContext<DBContext>(options =>
            options.UseSqlite("Data Source=Strekning.db"));

            services.AddScoped<IBilletRepository, BilletRepository>();

            services.AddScoped<IStrekningRepository, StrekningRepository>();

            StripeConfiguration.ApiKey = _config.GetSection("Stripe")["SecretKey"];


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddFile("Logs/BilletLog.txt");

                DBInit.Initialize(app);
                
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}