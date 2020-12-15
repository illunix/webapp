using Convey;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Web.Infrastructure;

namespace WebApplication4
{
    public static class Extensions
    {
        public static IConveyBuilder AddCore(this IConveyBuilder builder)
        {
            builder.Services.AddControllersWithViews()
                .AddFeatureFolders()
                .AddAreaFeatureFolders();

            builder.Services
                .Configure<RazorViewEngineOptions>(options =>
                {
                    options.ViewLocationExpanders.Add(new SubAreaViewLocationExpander());
                });

            return builder;
        }

        public static IApplicationBuilder UseCore(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(e =>
            {
                e.MapControllerRoute(
                    name: "subAreaRoute",
                    pattern: "{area:exists}/{subarea:exists}/{controller=Home}/{action=Index}/{id?}");
                e.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                e.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            return app;
        }
    }
}
