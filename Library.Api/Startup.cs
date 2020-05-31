using AutoMapper;
using Library.BL.Interfaces;
using Library.BL.Services;
using Library.DAL;
using Library.DAL.Interfaces;
using Library.DAL.Services;
using Library.Infrastructure;
using Library.Infrastructure.Registers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Library.Api
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
            services.AddSingleton(new Settings(Configuration));

            var settings = services.BuildServiceProvider().GetRequiredService<Settings>();

            RegisterStrategy.Register(settings, services);
            services.AddScoped<ILibraryService, LibraryService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IReaderService, ReaderService>();
            services.AddScoped<IBackupRepository, BackupRepository>();
            services.AddScoped<IBackupService, BackupService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();

            RepositoryListener.onUpdate += RepositoryListenerHandler.OnEntityModified;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
