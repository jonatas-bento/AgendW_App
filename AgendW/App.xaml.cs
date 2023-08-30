using AgendW.Services;
using AgendW.Views;

namespace AgendW
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App()
        {

            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            var loginPage = ActivatorUtilities.CreateInstance<LoginPage>(_serviceProvider);
            MainPage = new NavigationPage(loginPage);
        }
        void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            // Register other services as needed
        }
    }
}