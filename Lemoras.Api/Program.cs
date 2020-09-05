using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Lemoras.Api
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            Run<Startup>(args);
        }

        public static IWebHostBuilder CreateWebHostBuilder<TStartup>(string[] args)
            where TStartup : class
            => 
            WebHost.CreateDefaultBuilder(args).UseStartup<TStartup>();

        public static void Run<TStartup>(string[] args, bool forS3 = false) where TStartup : class
        {
            CreateWebHostBuilder<TStartup>(args).Build().Run();
        }

        public static void LambdaEntryPoint<TStartup>(IWebHostBuilder builder) where TStartup : class
        {
            builder.UseStartup<TStartup>();
        }
    }
}
