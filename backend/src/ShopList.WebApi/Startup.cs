using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopList.Business;
using ShopList.DataAccess;

namespace ShopList.WebApi
{
  public class Startup
  {
    private readonly IConfiguration _configuration;
    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddBusinessLogic();
      services.AddDataAccess(_configuration);

      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}
