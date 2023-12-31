using harmonee.Client;
using harmonee.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace harmonee.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { 
                BaseAddress = new Uri("http://localhost:5068/rest")
            });
			builder.Services.AddScoped<IApiClient, ApiClient>(/*sp => new ApiClient(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })*/);
            builder.Services.AddScoped<IFamilyService, FamilyService>();
			builder.Services.AddScoped<IFamilyEventService, FamilyEventService>();
			builder.Services.AddScoped<IFamilyListService, FamilyListService>();
			builder.Services.AddScoped<IFamilyMemberService, FamilyMemberService>();

			await builder.Build().RunAsync();
        }
    }
}
