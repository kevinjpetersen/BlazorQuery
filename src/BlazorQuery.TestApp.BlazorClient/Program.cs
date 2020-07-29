using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorQuery.TestApp.CommonLib;
using BlazorQuery.Library.Extensions;
using BlazorQuery.TestApp.CommonLib.Data;

namespace BlazorQuery.TestApp.BlazorClient
{
    // Note that we have some errors launching app : https://github.com/dotnet/aspnetcore/issues/20256
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddBlazorQuery();
            builder.Services.AddSingleton<WeatherForecastService>();
            await builder.Build().RunAsync();
        }

        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}

        //public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
        //    BlazorWebAssemblyHost.CreateDefaultBuilder()
        //        .UseBlazorStartup<Startup>();
    }
}
