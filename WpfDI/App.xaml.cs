using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AspectCore.Configuration;
using AspectCore.DynamicProxy;
using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WpfDI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            var services = new ServiceCollection();
            ConfigureServices(services);
            //var provider = services.BuildServiceProvider();
            var provider = services.BuildDynamicProxyProvider();

            var mainWindow = provider.GetService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<ITestService, TestService>();

            services.ConfigureDynamicProxy(config =>
            {
                config.Interceptors
                    .AddTyped<AopTestAttribute>(Predicates.ForService("*Service"));
            });
        }

        public IConfiguration Configuration { get; set; }
    }

    public class AopTestAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }

    public interface ITestService
    {
        void Do();

        int Get();

        Task DoAsync();

        Task<int> GetAsync();
    }

    public class TestService : ITestService
    {
        public void Do()
        {
            Debug.WriteLine("Do");
        }

        public int Get()
        {
            Debug.WriteLine("Get");
            return 10;
        }

        public async Task DoAsync()
        {
            await Task.Run(() => { Debug.WriteLine("DoAsync"); });
        }

        public Task<int> GetAsync()
        {
            return Task.Run(() =>
             {
                 Debug.WriteLine("GetAsync");
                 return 100;
             });
        }
    }
}