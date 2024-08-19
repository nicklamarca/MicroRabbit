using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<TransferDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection")));

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Transfer Microservice", Version = "v1" });
            });

            // Add MediatR FIX THIS
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


            DependencyContianer.RegisterServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservice V1"));

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
