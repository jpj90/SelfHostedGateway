using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace SelfHostedGateway
{
  class Startup1
  {
    public Startup1(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      //services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.Use(async (context, next) =>
      {
        Console.WriteLine($">>>>>>> incoming request: {context.Request.Path}");
        await next();
      });

      app.UseHttpsRedirection();

      app.UseRouting();

      //app.UseAuthorization();

      //app.UseEndpoints(endpoints =>
      //{
      //  endpoints.MapControllers();
      //});

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync(
            $"Hello user!");
      });

    }
  }
}
