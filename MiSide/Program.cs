using MiSide.Domain;
using MiSide.Infrastructure;

namespace MiSide
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            //IConfigurationBuilder configBuild = new ConfigurationBuilder()
            //    .SetBasePath(builder.Environment.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddEnvironmentVariables();

            //IConfiguration configuratioin = configBuild.Build();
            //AppConfig config = configuratioin.GetSection("Project").Get<AppConfig>()!;

            builder.Services.AddDataAccess();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

            //app.UseStaticFiles();

            //app.UseRouting();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            
            await app.RunAsync();
        }
    }
}
