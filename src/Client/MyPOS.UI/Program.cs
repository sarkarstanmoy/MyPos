using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using MyPOS.UI.BaseRemoteService.Http;
using System;
using System.Threading.Tasks;

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
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}