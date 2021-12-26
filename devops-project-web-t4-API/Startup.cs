using devops_project_web_t4.Data;
using devops_project_web_t4.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;

namespace devops_project_web_t4_API
{
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
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseMySql(Configuration.GetConnectionString("Mysql"), ServerVersion.AutoDetect(Configuration.GetConnectionString("Mysql")))); //https://dev.mysql.com/downloads/mysql/
                                                                                                                                                             //options.UseMySql(Configuration.GetConnectionString("Mysql"), ServerVersion.AutoDetect(Configuration.GetConnectionString("Mysql"))));

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["Auth0:Authority"];
                options.Audience = Configuration["Auth0:ApiIdentifier"];
                options.RequireHttpsMetadata = false;
            });

            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IMeetingRoomRepository, MeetingRoomRepository>();
            services.AddScoped<ICoworkReservationRepository, CoworkReservationRepository>();
            services.AddScoped<IMeetingroomReservationRepository, MeetingroomReservationRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "HIER API";
                c.Version = "v1";
                c.Description = "The HIER API documentation.";
                c.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey, // Use API keys for authorization. An API key is a token that a client provides when making API calls.
              Name = "Authorization", // Name of header to be used.
              In = OpenApiSecurityApiKeyLocation.Header, // Token is passed in the header.
              Description = "Type into the textbox: Bearer {your JWT token}." // Description above textfield to enter bearer token.
          });

                c.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT")); // Adds the token when a request is send.
      });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseOpenApi(); //Serves the registered OpenAPI/Swagger documents by default on `/swagger/{documentName}/swagger.json`
            app.UseSwaggerUi3(); //Serves the Swagger UI 3 web uito view the OpenAPI/Swagger documents by default on `/swagger`

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
