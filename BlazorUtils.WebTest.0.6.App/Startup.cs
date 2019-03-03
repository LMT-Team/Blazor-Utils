using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace BlazorUtils.WebTest._0._6.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Since Blazor is running on the server, we can use an application service
            // to read the forecast data.

            services.AddScoped<HttpClient>(s =>
            {
                // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.
                var uriHelper = s.GetRequiredService<IUriHelper>();
                return new HttpClient
                {
                    BaseAddress = new Uri(uriHelper.GetBaseUri())
                };
            });
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
