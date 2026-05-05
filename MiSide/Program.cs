using Api;
using Api.Configuration;
using MiSide.Domain;

namespace MiSide
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDataAccess();
            builder.Services.AddBusinessLogic();
            builder.Services.Configure<AuthenticationSettings>(
                builder.Configuration.GetSection("AuthenticationSettings"));
            builder.Services.AddAuthentication(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.MapControllers();
            
            await app.RunAsync();
        }
    }
}
