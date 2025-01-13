using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TruthORDrink.MVVM.ViewModel;
using TruthORDrink.MVVM.Views;

namespace TruthORDrink
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Configureer de database repository en andere services
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TruthORDrink.db");
            builder.Services.AddSingleton(new DatabaseRepository(dbPath));

            // Voeg de ViewModels en Pages toe aan de DI-container
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<NewSessionPage>();
            builder.Services.AddSingleton<QuestionPage>();
            builder.Services.AddSingleton<PlayerPage>();
            builder.Services.AddSingleton<GamePage>();

            builder.Services.AddSingleton<GameViewModel>();
            builder.Services.AddSingleton<PlayerViewModel>();
            builder.Services.AddSingleton<QuestionViewModel>();
            
            builder.Services.AddSingleton(sp =>
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://localhost:port/") // Vervang 'port' door jouw API-poort
                };
                return httpClient;
            });
            builder.Services.AddSingleton<ApiService>();  //registeer de apiservice

            return builder.Build();
        }
    }
}