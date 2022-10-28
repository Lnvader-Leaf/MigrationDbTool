using GZY.Quartz.MUI.EFContext;
using GZY.Quartz.MUI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MigrationDbForEF.AutoMapperConfig;
using MigrationDbForEF.EfDbContext;
using MigrationDbForEF.IRespositoryConfig;
using MigrationDbForEF.IService;
using MigrationDbForEF.RespositoryConfig;
using MigrationDbForEF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF
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

            services.AddControllers();
            services.AddDbContext<OracleDbContext>(options =>
                  options.UseOracle(Configuration.GetConnectionString("OracleConnectionString"),b => b.UseOracleSQLCompatibility("11")));
            services.AddDbContext<SqlServerDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnectionString")));
            services.AddDbContext<MySqlDbContext>(options =>
                  options.UseMySQL(Configuration.GetConnectionString("MySqlConnectionString")));
            services.AddQuartzUI();
            services.AddAutoMapper(typeof(ServerProFile));
            services.AddScoped<IEFMigrationServices, EFMigrationServices>();
            services.AddScoped<IRespository_Wrapper, Respository_Wrapper>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MigrationDbForEF", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MigrationDbForEF v1"));
            app.UseQuartz();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
