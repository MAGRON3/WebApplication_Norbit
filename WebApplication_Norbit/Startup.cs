using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication_Norbit.Models;

namespace WebApplication_Norbit
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string projectdbstore = "Server=(localdb)\\mssqllocaldb;Database=projectsdbstore;Trusted_Connection=True;";
            string taskdbstore = "Server=(localdb)\\mssqllocaldb;Database=tasksdbstore;Trusted_Connection=True;";
            string wiringdbstore = "Server=(localdb)\\mssqllocaldb;Database=wiringsdbstore;Trusted_Connection=True;";
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(projectdbstore));
            services.AddDbContext<TaskContext>(options => options.UseSqlServer(taskdbstore));
            services.AddDbContext<WiringContext>(options => options.UseSqlServer(wiringdbstore));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                    });
            });
            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
