
using APIEndPoint.Models.Interfaces;
using APIEndPoint.Models.Methods;
using App.Domain.AppServices.MoayeneFani.Cars;
using App.Domain.AppServices.MoayeneFani.Oprators;
using App.Domain.AppServices.MoayeneFani.OutOfServices;
using App.Domain.AppServices.MoayeneFani.Requests;
using App.Domain.AppServices.MoayeneFani.Users;
using App.Domain.AppServices.MoayeneFani.UsersCars;
using App.Domain.Core.MoayeneFani.Cars.AppService;
using App.Domain.Core.MoayeneFani.Cars.Data.Repositories;
using App.Domain.Core.MoayeneFani.Cars.Service;
using App.Domain.Core.MoayeneFani.Operators.AppService;
using App.Domain.Core.MoayeneFani.Operators.Data.Repositories;
using App.Domain.Core.MoayeneFani.Operators.Service;
using App.Domain.Core.MoayeneFani.OutOfServices.AppService;
using App.Domain.Core.MoayeneFani.OutOfServices.Data.Repositories;
using App.Domain.Core.MoayeneFani.OutOfServices.Service;
using App.Domain.Core.MoayeneFani.Requests.AppService;
using App.Domain.Core.MoayeneFani.Requests.Data.Repositories;
using App.Domain.Core.MoayeneFani.Requests.Service;
using App.Domain.Core.MoayeneFani.Users.AppService;
using App.Domain.Core.MoayeneFani.Users.Data.Repositories;
using App.Domain.Core.MoayeneFani.Users.Service;
using App.Domain.Core.MoayeneFani.UsersCars.AppService;
using App.Domain.Core.MoayeneFani.UsersCars.Data.Repositories;
using App.Domain.Core.MoayeneFani.UsersCars.Service;
using App.Domain.Services.MoayeneFani.Cars;
using App.Domain.Services.MoayeneFani.Oprators;
using App.Domain.Services.MoayeneFani.OutOfServices;
using App.Domain.Services.MoayeneFani.Requests;
using App.Domain.Services.MoayeneFani.Users;
using App.Domain.Services.MoayeneFani.UsersCars;
using App.Infra.Data.Repos.Ef.MoayeneFani.Cars;
using App.Infra.Data.Repos.Ef.MoayeneFani.Oprators;
using App.Infra.Data.Repos.Ef.MoayeneFani.OutOfServices;
using App.Infra.Data.Repos.Ef.MoayeneFani.Requests;
using App.Infra.Data.Repos.Ef.MoayeneFani.Users;
using App.Infra.Data.Repos.Ef.MoayeneFani.UsersCars;
using Connection;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace APIEndPoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-7D9S1GO;Initial Catalog=MoayeneFani;Integrated Security=SSPI;TrustServerCertificate=True;"));
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICarAppService, CarAppService>();
            builder.Services.AddScoped<IOpratorRepository, OpratorRepository>();
            builder.Services.AddScoped<IOpratorService, OpratorService>();
            builder.Services.AddScoped<IOpratorAppService, OpratorAppService>();
            builder.Services.AddScoped<IRequsetRepository, RequestRepository>();
            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddScoped<IRequestAppService, RequestAppService>();
            builder.Services.AddScoped<IOutOfServiceRepository, OutOfServiceRepository>();
            builder.Services.AddScoped<IOutOfServiceService, OutOfServiceService>();
            builder.Services.AddScoped<IOutOfServiceAppService, OutOfServiceAppService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserAppService, UserAppService>();
            builder.Services.AddScoped<IUserCarRepository, UserCarRepository>();
            builder.Services.AddScoped<IUserCarService, UserCarService>();
            builder.Services.AddScoped<IUserCarAppService, UserCarAppService>();
            builder.Services.AddScoped<ICheckRequestInfo,CheckRequestInfo>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
