using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Prt.Graphit.Application;
using Prt.Graphit.Application.Common.Handlers;
using Prt.Graphit.Application.Common.Interfaces;
using Prt.Graphit.Api.Extensions;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Prt.Graphit.Application.Interfaces;
using Prt.Graphit.Identity.Common;
using Prt.Graphit.Infrastructure;
using Prt.Graphit.Api.Common.Settings.Models;
using Microsoft.CodeAnalysis.Options;
using Host = Prt.Graphit.Api.Common.Settings.Models.Host;
using System;
using Prt.Graphit.Application.Common.MapperProfiles;

namespace Prt.Graphit.Api
{
    public class Startup
    {
        private readonly Assembly _assemblyApplication = typeof(HandlerBase<,>).GetTypeInfo().Assembly;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.AddLogging(Configuration);
            services.AddControllers()
               .AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IAppDbContext>());

            services.AddOptions();

            services
                    .AddPersistence(Configuration)
                    .AddAutoMapper(_assemblyApplication)
                    .AddApplication();

            services.AddTransient<IJwtManager, JwtManager>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthorizationOptions.ISSUER,

                        ValidateAudience = true,
                        ValidAudience = AuthorizationOptions.AUDIENCE,

                        ValidateLifetime = true,

                        IssuerSigningKey = AuthorizationOptions.Create(AuthorizationOptions.KEY),
                        ValidateIssuerSigningKey = true
                    };
                });

            
            //var corsParams = Configuration.GetSection("Cors").Get<List<string>>();
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                //corsParams.Where(x => x != null).ToArray()
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                                
                       //.AllowAnyMethod()
                       //.AllowAnyHeader()
                       //.AllowCredentials()
            }));

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"{nameof(Prt.Graphit.Api)}",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                    {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                    }
                   },
                   new string[] { }
                 }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.CustomSchemaIds(x => x.FullName);
                c.EnableAnnotations();
            });

            services.Configure<MapCatalog>(opt =>
            {
                opt.Path = Configuration["MapCatalog:Path"];
            });
            services.Configure<PictureCatalog>(opt =>
            {
                opt.Path = Configuration["PictureCatalog:Path"];
            });
            services.Configure<OperationSystem>(opt =>
            {
                opt.Platform = System.Environment.OSVersion.Platform;
            });
            services.Configure<Host>(opt=> 
            {
                opt.Address = Configuration["Host:Address"];
            });

            services.AddAutoMapper(_assemblyApplication);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prt.Graphit.Api V1");
            });

            // app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
