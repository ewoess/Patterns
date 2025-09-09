using System.Windows;
using Patterns.DataAccess;
using Patterns.DataAccess.Mock;
using Patterns.DataAccess.Models;
using Patterns.Domain.Services;
using Patterns.Wpf.Views;
using Prism.DryIoc;
using Prism.Ioc;

namespace Patterns.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // containerRegistry.Register<MainWindowViewModel>();
            containerRegistry.Register<IRepository<CircleEntity>, CircleRepository>();
            containerRegistry.Register<IRepository<RectangleEntity>, RectangleRepository>();
            
            containerRegistry.RegisterSingleton<CachingRepository<CircleEntity>>();
            containerRegistry.RegisterInstance<ICachingRepository<CircleEntity>>(Container.Resolve<CachingRepository<CircleEntity>>());
            containerRegistry.RegisterInstance<ICacheWarmable>(Container.Resolve<CachingRepository<CircleEntity>>());

            containerRegistry.RegisterSingleton<CachingRepository<RectangleEntity>>();
            containerRegistry.RegisterInstance<ICachingRepository<RectangleEntity>>(Container.Resolve<CachingRepository<RectangleEntity>>());
            containerRegistry.RegisterInstance<ICacheWarmable>(Container.Resolve<CachingRepository<RectangleEntity>>());

            containerRegistry.Register<IShapeService, ShapesService>();
        }

        protected override Window CreateShell()
        {
            IEnumerable<ICacheWarmable>? warmables = Container.Resolve<IEnumerable<ICacheWarmable>>();
            foreach (ICacheWarmable warmable in warmables)
            {
                warmable.WarmUp(); // Preload all caches
            }

            var shellWindow = Container.Resolve<MainWindow>();
            return shellWindow;
        }
    }

}
