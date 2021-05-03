using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // AddHttpClient comes from the Microsoft.Extentions.Http NuGet package.
            builder.Services.AddHttpClient("CvAPI", clientConfig =>
            {
                clientConfig.BaseAddress = new Uri("https://dynamiccv.azurewebsites.net/api/");
                clientConfig.Timeout = TimeSpan.FromSeconds(10);
            });

            await builder.Build().RunAsync();
        }
    }
}
