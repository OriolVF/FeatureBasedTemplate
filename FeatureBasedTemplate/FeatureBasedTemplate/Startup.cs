using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeatureBasedTemplate.Ardalis.CoreFeatureFolders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureBasedTemplate
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o => o.Conventions.Add(new FeatureConvention()))
                .AddRazorOptions(options =>
                {
                    // {0} - Action Name
                    // {1} - Controller Name
                    // {2} - Feature Name
                    // Replace normal view location entirely
                    options.ViewLocationFormats.Clear();
                    options.ViewLocationFormats.Add("/Features/{2}/{1}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Features/{2}/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");
                    options.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
