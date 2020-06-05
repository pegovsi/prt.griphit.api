using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Prt.Graphit.Api.Common.Settings.Models;
using Prt.Graphit.Application.Common.MapperProfiles;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Prt.Graphit.Api.Extensions
{
    public static class AutoMapperStartupExtensions
    {
        
        public static void AutoMapperConfigure(this IWebHostEnvironment env, 
            Assembly assembly, IApplicationBuilder app)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(assembly);
            });

            if (env != null && env.IsDevelopment())
            {
                //var opt = app.ApplicationServices
                //.GetRequiredService<Microsoft.Extensions.Options.IOptions<Common.Settings.Models.Host>>();

                try
                {
                    
                    config.AssertConfigurationIsValid();
                }
                catch (Exception e)
                {
                    Debugger.Break();
                    throw;
                }
            }
        }
    }
}
