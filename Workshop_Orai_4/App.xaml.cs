using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using System.Configuration;
using System.Data;
using System.Windows;
using Workshop_Orai_4.Services;
using Microsoft.Extensions.DependencyInjection;
using Workshop_Orai_4.Logic;

namespace Workshop_Orai_4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<IFoodLogic, FoodLogic>()
                    .AddSingleton<ISnackEditorViaWindow, SnackEditorViaWindow>()
                    .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                    .BuildServiceProvider());
        }
    }

}
