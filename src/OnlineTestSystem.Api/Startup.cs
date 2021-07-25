using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineTestSystem.Api.Data;
using OnlineTestSystem.Api.Data.Contracts;
using OnlineTestSystem.Api.Infrastructure.Extensions;
using OnlineTestSystem.Api.Models;
using OnlineTestSystem.Api.Models.Contracts;
using OnlineTestSystem.Api.Services;

namespace OnlineTestSystem.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationContext>(o => 
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

            services.AddJwtAuthentication(Configuration);
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();

            services.AddCors();

            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseCors(opts =>
            {
                opts.AllowAnyMethod();
                opts.AllowAnyHeader();
                opts.AllowAnyOrigin();
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.SeedData();
        }
    }
}
