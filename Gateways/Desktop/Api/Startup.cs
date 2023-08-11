namespace ProlecGE.ControlPisoMX.BFWeb.Components.Api
{
    using Hellang.Middleware.ProblemDetails;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddMonolithicGateway(
            //    Configuration.GetSection("MonolithicSettings:ERP"),
            //    Configuration.GetSection("MonolithicSettings:Cores"),
            //    "User Id=dis_ctp; Password=necesary;Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 503))(CONNECT_DATA = (SID = BAAN)));",
            //    "Data Source=127.0.0.1,510;Initial Catalog=thingworx_storage;User ID=NucleosRtMPAdmin_data;Password=NucL30sMP.D4t4.0321;Persist Security Info=True;MultipleActiveResultSets=True",
            //    "User Id=dis_ctp; Password=necesary;Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 503))(CONNECT_DATA = (SID = BAAN)));",
            //    "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=MicroBAAN;Integrated Security=True;MultipleActiveResultSets=True;",
            //    "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=MicroBAAN;Integrated Security=True;MultipleActiveResultSets=True;"
            //   );

            services.AddHttpServices(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Components Gateway",
                        Version = "v1"
                    });
                c.EnableAnnotations();
                c.CustomSchemaIds(type => type.ToString());
            });

            services.AddProblemDetails(opts =>
              {
                  opts.Map<System.UserException>(userException => new Microsoft.AspNetCore.Mvc.ProblemDetails
                  {
                      Status = userException.IsInternalException ?
                          StatusCodes.Status500InternalServerError :
                          StatusCodes.Status400BadRequest,
                      Title = userException.Message,
                      Extensions =
                      {
                        { "errorCode", userException.ErrorCode }
                      }
                  });

                  opts.IncludeExceptionDetails = (ctx, ex) =>
                  {
                      // Fetch services from HttpContext.RequestServices
                      IHostEnvironment env = ctx.RequestServices.GetRequiredService<IHostEnvironment>();
                      return env.IsDevelopment() || env.IsStaging();
                  };
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpsRedirection();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                  c.SwaggerEndpoint(
                      "./v1/swagger.json",
                      "Components Gateway v1"));

            app.UseProblemDetails();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }

    public static class MicroserviceServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddHttpClient<ControlPisoMX.Legacy.IMicroservice, ControlPisoMX.Legacy.Api.LegacyMicroservice>("legacy", client => client.BaseAddress = new System.Uri(configuration.GetSection("MicroservicesUrls:Legacy").Value));

            services.AddHttpClient<ControlPisoMX.ERP.IMicroservice, ControlPisoMX.ERP.Api.ERPMicroservice>("erp", client => client.BaseAddress = new System.Uri(configuration.GetSection("MicroservicesUrls:ERP").Value));

            services.AddHttpClient<ControlPisoMX.I40.IMicroservice, ControlPisoMX.I40.Api.I40Microservice>("i40", client => client.BaseAddress = new System.Uri(configuration.GetSection("MicroservicesUrls:I40").Value));

            services.AddHttpClient<ControlPisoMX.Cores.IMicroservice, ControlPisoMX.Cores.Api.CoresMicroservice>("cores", client => client.BaseAddress = new System.Uri(configuration.GetSection("MicroservicesUrls:Cores").Value));

            services.AddHttpClient<ControlPisoMX.Insulations.IMicroservice, ControlPisoMX.Insulations.Api.InsulationsMicroservice>("insulations", client => client.BaseAddress = new System.Uri(configuration.GetSection("MicroservicesUrls:Insulations").Value));

            services.AddHttpClient<ControlPisoMX.InspectionCMS.IMicroservice, Services.InspectionCMSHttpMicroservice>("inspection", client => client.BaseAddress = new System.Uri(configuration.GetSection("MicroservicesUrls:InspectionCMS").Value));

            //services.AddHttpClient<ControlPisoMX.LN.IMicroservice, ControlPisoMX.LN.Api.LNMicroservice>("ln", client => client.BaseAddress = new System.Uri(configuration.GetSection("MicroservicesUrls:LN").Value));

            services.AddHttpClient<IComboService, ComboService>("combo", client => client.BaseAddress = new System.Uri(configuration.GetSection("MicroservicesUrls:ERP").Value));
            services.AddComponentsGateway();

            return services;
        }
    }
}