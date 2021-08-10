using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using MyPOS.UI.BaseRemoteService.Http;

namespace MyPOS.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddHttpClient("LoginAPI",
                                            client => client.BaseAddress = new Uri("http://localhost:57915/api/v1/Account/"));
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            await builder.Build().RunAsync();
        }
    }
}