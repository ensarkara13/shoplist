using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopList.Business;
using ShopList.DataAccess;
using ShopList.WebApi.Models;
using System.Security.Claims;

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
      services
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
      {
        TokenOption tokenOption = _configuration.GetSection("TokenOption").Get<TokenOption>();
        options.TokenValidationParameters = new TokenValidationParameters()
        {
          // RoleClaimType = new Claim("Ensar", "Admin").Type,
          RoleClaimType = ClaimTypes.Role,
          ValidateAudience = true,
          ValidateIssuer = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = tokenOption.Issuer,
          ValidAudience = tokenOption.Audience,
          IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(tokenOption.Key))
        };
      });

      services.AddBusinessLogic();
      services.AddDataAccess(_configuration);

      services.AddControllers();
      services.AddCors();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors(opt =>
      {
        opt.AllowAnyHeader();
        opt.AllowAnyMethod();
        opt.AllowAnyOrigin();
      });

      app.UseAuthentication();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}
