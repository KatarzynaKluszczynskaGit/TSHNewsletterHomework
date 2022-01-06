using Microsoft.Extensions.Configuration;
using TSHNewsletterHomework.Models;

namespace TSHNewsletterHomework
{
    public class Configuration
    {
        public static WebDriverConfiguration Driver => GetConfiguration()
            .GetSection("WebDriverSection").Get<WebDriverConfiguration>();

        public static MailSacConfiguration MailSac => GetConfiguration()
            .GetSection("MailSacSection").Get<MailSacConfiguration>();

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            return builder.Build();
        }
    }
}