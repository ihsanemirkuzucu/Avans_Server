using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IAdvance;
using AvansProjeServer.BLL.Abstract.IAuth;
using AvansProjeServer.BLL.Abstract.IProject;
using AvansProjeServer.BLL.Abstract.ITitle;
using AvansProjeServer.BLL.Abstract.IUnit;
using AvansProjeServer.BLL.Abstract.IWorker;
using AvansProjeServer.BLL.AdvanceApproveStragy;
using AvansProjeServer.BLL.Concrete.Advance;
using AvansProjeServer.BLL.Concrete.Auth;
using AvansProjeServer.BLL.Concrete.Project;
using AvansProjeServer.BLL.Concrete.Title;
using AvansProjeServer.BLL.Concrete.Unit;
using AvansProjeServer.BLL.Concrete.Worker;

using AvansProjeServer.DAL.Abstract.IAuth;
using AvansProjeServer.DAL.Abstract.IProject;
using AvansProjeServer.DAL.Abstract.ITitle;
using AvansProjeServer.DAL.Abstract.IUnit;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServer.DAL.Concrete;
using AvansProjeServer.DAL.Context;
using AvansProjeServer.DTO.MyMapper;
using AvansProjeServerDAL.Abstract.IAdvance;
using AvansProjeServerDAL.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace AvansProjeServer.API
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
            services.AddScoped<MyConnectionContext>();
            services.AddScoped<MyMapper>();

            services.AddScoped<IAuthBLL, AuthBLL>();
            services.AddScoped<IAuthDAL, AuthDAL>();

            services.AddScoped<IWorkerDAL, WorkerDAL>();
            services.AddScoped<IWorkerBLL, WorkerBLL>();

            services.AddScoped<ITitleBLL, TitleBLL>();
            services.AddScoped<ITitleDAL, TitleDAL>();

            services.AddScoped<IUnitBLL, UnitBLL>();
            services.AddScoped<IUnitDAL, UnitDAL>();

            services.AddScoped<IProjectBLL, ProjectBLL>();
            services.AddScoped<IProjectDAL, ProjectDAL>();

            services.AddScoped<ApproveFlow>();

            services.AddScoped<IAdvanceBLL, AdvanceBLL>();
            services.AddScoped<IAdvanceDAL, AdvanceDAL>();


            var gizlibilgi = Encoding.ASCII.GetBytes(Configuration.GetSection("apisecretkey").Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(gizlibilgi),
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidAudience = "Fineksus",
                    ValidIssuer = "Ýhsan"
                };
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AvansProjeServer.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AvansProjeServer.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
