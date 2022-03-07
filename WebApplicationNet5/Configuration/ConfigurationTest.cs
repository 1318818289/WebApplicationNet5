using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace WebApplicationNet5
{
    public class ConfigurationTest
    {

        public static void Show1(IConfiguration configurtion)
        {
            Console.WriteLine("Show1=" + configurtion["Logging:LogLevel:Default"]);

            var configRoot = (IConfigurationRoot)configurtion;
            foreach (var provider in configRoot.Providers)
            {
                Console.WriteLine(provider.ToString() + "\n");
            }
        }

        public static void Show2(IConfiguration configurtion)
        {
            LogLevelOptions options = new LogLevelOptions();
            configurtion.Bind("Logging:LogLevel", options);

            Console.WriteLine("Show2=" + options.Default);
        }

        public static void Show3(IServiceCollection services, IConfiguration configurtion)
        {
            services.Configure<LogLevelOptions>(configurtion.GetSection("Logging:LogLevel"));

            //构造函数注入或手动获取注册对象
            var provider = services.BuildServiceProvider();
            var logLevelOptions1 = provider.GetService<IOptionsMonitor<LogLevelOptions>>();
            var logLevelOptions2 = provider.GetService<IOptions<LogLevelOptions>>();

            IOptionsMonitor<LogLevelOptions> optionsMonitor = logLevelOptions1;
            IOptions<LogLevelOptions> options = logLevelOptions2;

            Console.WriteLine("Show3-1=" + optionsMonitor.CurrentValue.Default);
            Console.WriteLine("Show3-2=" + options.Value.Default);

        }

    }
}
