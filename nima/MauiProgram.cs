using nima.Data;
using Microsoft.Extensions.Logging;
using nima.Services;
namespace nima;

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

        builder.Services.AddMauiBlazorWebView();

        builder.Services.AddSingleton<TodoStorage>();
        builder.Services.AddSingleton<NotificationService>();
        builder.Services.AddSingleton<ExportService>();


        return builder.Build();
    }
}