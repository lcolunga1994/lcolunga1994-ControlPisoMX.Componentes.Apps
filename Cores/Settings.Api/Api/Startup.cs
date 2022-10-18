namespace ProlecGE.ControlPisoMX.Cores.Testing.Settings.Api
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
            services.AddSwaggerGen(c => c.SwaggerDoc(
                      "v1",
                      new OpenApiInfo
                      {
                          Title = "Control Piso MX Apps Settings Api",
                          Version = "v1"
                      }));

            services.AddCoreTestingApiServices(Configuration.GetConnectionString("CoresTesting"));

            services.AddProblemDetails(opts =>
            {
                opts.Map<System.UserException>(userException => new Microsoft.AspNetCore.Mvc.ProblemDetails
                {
                    Status = userException.IsInternalException ?
                        StatusCodes.Status500InternalServerError :
                        StatusCodes.Status400BadRequest,
                    Title = userException.Message,
                    Extensions = { { "errorCode", userException.ErrorCode } }
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
            app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "Apps Settings v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}