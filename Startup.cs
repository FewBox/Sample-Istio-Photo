using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample_Istio_Photo.Configs;
using Sample_Istio_Photo.Repositories;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Sample_Istio_Photo.AutoMapperProfiles;
using System;
using System.Reflection;

namespace Sample_Istio_Photo
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
            services.AddCors();
            services.AddAutoMapper();
            // services.AddMemoryCache();
            // services.AddHttpContextAccessor();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var unsplashApiConfig = this.Configuration.GetSection("UnsplashApiConfig").Get<UnsplashApiConfig>();
            var reviewApiConfig = this.Configuration.GetSection("ReviewApiConfig").Get<ReviewApiConfig>();
            services.AddSingleton(unsplashApiConfig);
            services.AddSingleton(reviewApiConfig);
            services.AddScoped<IUnsplashRepository, UnsplashRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FewBox API", Version = "v1" });
                // c.SwaggerDoc("v2", new Info { Title = "FewBox API", Version = "v2" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder => {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
            });
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseStaticFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FewBox API V1");
                // c.SwaggerEndpoint("/swagger/v2/swagger.json", "FewBox API V2");
                c.RoutePrefix = String.Empty;
            });
        }
    }
}