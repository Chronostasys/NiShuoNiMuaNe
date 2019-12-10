using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public class Startup
    {
        public static LimFxApi.Client client = new LimFxApi.Client("https://localhost:44349/", new System.Net.Http.HttpClient());
        static public string html="";
        public void ConfigureServices(IServiceCollection service)
        {
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
