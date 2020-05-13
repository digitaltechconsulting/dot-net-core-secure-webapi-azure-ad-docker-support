//https://techconsulting.com.au/
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SecureWebApi.Interfaces;
using SecureWebApi.Services;
namespace SecureWebApi
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
			services.AddCors(setupAction =>
			{
				setupAction.AddPolicy("default", p =>
				{
					p.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
				});
			});
			services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
				.AddAzureADBearer(options => {
					var readAzureAdFromEnvironment = Environment.GetEnvironmentVariable(EnvVariables.READ_AZUREAD_FROM_ENVIRONMENT);
					if ( !string.IsNullOrEmpty(readAzureAdFromEnvironment) && readAzureAdFromEnvironment.ToUpper().Equals("TRUE") )
					{
						var INSTANCE = Environment.GetEnvironmentVariable(EnvVariables.INSTANCE);
						var DOMAIN = Environment.GetEnvironmentVariable(EnvVariables.DOMAIN);
						var TENANTID = Environment.GetEnvironmentVariable(EnvVariables.TENANTID);
						var CLIENTID = Environment.GetEnvironmentVariable(EnvVariables.CLIENTID);
						options.Instance = INSTANCE;
						options.Domain = DOMAIN;
						options.ClientId = CLIENTID;
						options.TenantId = TENANTID;
					}
					else
					{
						Configuration.Bind("AzureAd", options);
					}
				});
			services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, options => 
			{
				options.Events = new JwtBearerEvents
				{
					OnTokenValidated = OnTokenValidated
				};

				//options.Audience = "api://55a047a1-a0d1-4b6b-9896-751a848e1e06";
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					//I have kept these settings in place to provide easy support for docker.
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
			services.AddControllers();

			services.AddTransient<ICheckout,CheckoutService>();
		}

		Task OnTokenValidated(Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext context)
		{
			return Task.CompletedTask;
		}


		public AzureADOptions GetAzureADOptions()
		{
			AzureADOptions azureADOptions = new AzureADOptions();

			return azureADOptions;
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//app.UseHttpsRedirection();
			app.UseCors("default");

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
