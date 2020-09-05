using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lemoras.Domain.Parts;

namespace Lemoras.Api.Utils
{
    public class SecretKeyProvider : ISecretKeyProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public SecretKeyProvider(IConfiguration configuration, IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;
        }

        public byte[] GetSecretKey()
        {
            var appSettingsSection = _configuration.GetSection("AppSettings");
            _services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            //return Encoding.ASCII.GetBytes(appSettings.Secret);
            return Encoding.UTF8.GetBytes(appSettings.Secret);
        }
    }
}
