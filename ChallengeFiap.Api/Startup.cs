using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ChallengeFiap.Data.Context;
using ChallengeFiap.Api.Configure;
using Microsoft.Extensions.PlatformAbstractions;

using System.IO;

namespace ChallengeFiap.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDatabaseSetup(Configuration);
      services.AddIdentitySetup(Configuration);
      services.AddDbContext<ApplicationDbContext>();
      services.AddCors();
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
      services.AddControllers();
      //services.AddSwaggerGen(c =>
      //{
      //  c.SwaggerDoc("v1",
      //      new Microsoft.OpenApi.Models.OpenApiInfo
      //      {
      //        Title = "Challenger Fiap",
      //        Version = "v1",
      //        Description = "Api para um sistema de criação de eventos para mulheres"
      //      });

      //  string caminhoAplicacao =
      //      PlatformServices.Default.Application.ApplicationBasePath;
      //  string nomeAplicacao =
      //      PlatformServices.Default.Application.ApplicationName;
      //  string caminhoXmlDoc =
      //      Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

      //  c.IncludeXmlComments(caminhoXmlDoc);
      //});
   
      services.AddSwaggerSetup();
      services.RegisterServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseDeveloperExceptionPage();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
      );

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json",
            "Challenger Fiap");
      });
    }
  }
}
