using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Google;
using Newtonsoft.Json.Serialization;

namespace Phoenix
{
    /// <summary> Represents the site startup configuration. </summary>
    public class Startup
    {
        /// <summary> The constructor. </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary> Gets the site configuration information. </summary>
        public IConfiguration Configuration { get; }

        /// <summary> This method gets called by the runtime. Use this method to add services to the container. </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //TODO: ADD THIS after we get the Appraisal form working
            /* services.AddIdentity<IdentityUser, IdentityRole>();
             services.AddAuthentication(
                     v =>
                     {
                         v.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                         v.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                     }).AddGoogle(googleOptions =>
                     {
                         googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                         googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                     }); */

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DealContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DealContext")));
            services
                .AddMvc()
                .AddJsonOptions(options =>
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddKendo();
        }

        /// <summary> This method gets called by the runtime. Use this method to configure the HTTP request pipeline. </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseKendo(env);

            //TODO: ADD THIS after we get the Appraisal form working
            app.UseAuthentication()
               .UseMvc();
            //app.UseMvc();
        }
    }
}
