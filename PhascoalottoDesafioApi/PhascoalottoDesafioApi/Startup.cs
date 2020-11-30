using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using PhascoalottoDesafio.Aplicacao;
using PhascoalottoDesafio.Aplicacao.Base;
using PhascoalottoDesafio.Infraestrutura;
using PhascoalottoDesafio.Infraestrutura.Adapters;
using PhascoalottoDesafio.Infraestrutura.Base;
using PhascoalottoDesafio.Infraestrutura.Seed;
using PhascoalottoDesafio.Infraestrutura.Transversal;
using PhascoalottoDesafio.Infraestrutura.UnitOfWork;
using PhascoalottoDesafioApi.Base;
using System;
using System.IO;

namespace PhascoalottoDesafioApi
{
    public class Startup
    {
        private string _webRootPath;


        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            _webRootPath = env.WebRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureMvc(services);
            ConfigureIoC(services);
            ConfigureInfra(services);
            ConfigureCors(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitializeDbData(app, Configuration);

            app.UseCors("default");
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvcWithDefaultRoute();

            // To use wwwroot folder
            string pathWwwRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            Tools.CreateDirectory(pathWwwRoot);

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = "/wwwroot"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = "/wwwroot"
            });
        }

        private void ConfigureMvc(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddJsonFormatters()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .AddViews()
                .AddRazorViewEngine();
        }

        private void ConfigureIoC(IServiceCollection services)
        {
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<DbUnitOfWork>();
            services.AddTransient<ITypeAdapterFactory, AutomapperTypeAdapterFactory>();
            services.AddSingleton<IConfiguration>(Configuration);
        }

        private void ConfigureInfra(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var typeAdapterFactory = sp.GetService<ITypeAdapterFactory>();

            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    string[] corsOrigins = new string[] { "http://localhost:3000" };

                    policy.WithOrigins(corsOrigins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        private void InitializeDbData(IApplicationBuilder app, IConfiguration configuration)
        {
            try
            {
                using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var repositoryFactory = scope.ServiceProvider.GetRequiredService<IRepositoryFactory>();

                    SeedDataBase.MigrateDatabase(repositoryFactory);
                    SeedDataBase.SeedDatabase(repositoryFactory);
                }
            }
            catch (Exception ex)
            {
                string pathLog = _webRootPath.Replace("wwwroot", "logs");
                string pathFile = pathLog + "\\log-InitializeDbData.txt";

                if (!Directory.Exists(pathLog))
                    Directory.CreateDirectory(pathLog);

                if (File.Exists(pathFile))
                    File.Delete(pathFile);

                File.WriteAllText(pathFile, "InitializeDbData Error: " + ex.Message);
            }
        }
    }
}
