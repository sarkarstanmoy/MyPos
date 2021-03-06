using Identity.API.Infrastructure;
using Identity.API.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Identity.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity.API", Version = "v1" });
            });

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));
            services.AddDbContext<IdentityContext>(options =>
            options.UseMySql("server=host.docker.internal;port=33061;user=root;password=root123;database=account", serverVersion)
                   .EnableSensitiveDataLogging()
                   .EnableDetailedErrors());

            services.AddScoped<IIdentityRepository, IdentityRepository>();

            services.AddMediatR(typeof(Startup).Assembly);
            services.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", opt => opt
                    .AllowAnyOrigin()
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}