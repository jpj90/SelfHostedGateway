using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace SelfHostedGateway
{
  class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder
          .ConfigureAppConfiguration((hostingContext, config) => {
            config
              .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
              .AddJsonFile("ocelot.json");
          })
          .UseStartup<Startup1>();
        });
  }
}
