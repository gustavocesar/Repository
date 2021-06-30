using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Infrastructure.Context;
using SharedKernel.Infrastructure.UnitOfWork;
using Infrastructure.UnitOfWork;
using Application.Commands.Contracts;
using Application.Commands;
using Domain.Repositories.Contracts;
using Infrastructure.Persistence.Repositories;
using SharedKernel.Infrastructure.DataContext;

namespace Repository
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Repository", Version = "v1" });
            });

            services.AddDbContext<DataContext>(
                options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FooTests;Trusted_Connection=True;")
            );

            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFooCommandServiceApplication, FooCommandServiceApplication>();
            services.AddScoped<IFooRepository, FooRepository>();
            services.AddScoped<IBarRepository, BarRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Repository v1"));
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
