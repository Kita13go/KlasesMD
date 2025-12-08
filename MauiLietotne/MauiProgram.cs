using Microsoft.Extensions.Logging;

namespace MauiLietotne
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
            //Varam lietot to implementāciju, kura patīk
            //      builder.Services.AddTransient<ViewModel.IRectangleViewModel, ViewModel.RectanglesViewModelLite>();
            builder.Services.AddTransient<ViewModel.IITSupportViewModel, ViewModel.ITSupportsViewModel>();
            builder.Services.AddTransient<Views.ITSupportView>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
