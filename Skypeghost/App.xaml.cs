
namespace Skypeghost
{
    using System.Windows;
    using Microsoft.Practices.Unity;
    using Skypeghost.Views;
    using Skypeghost.Models;
    using Skypeghost.DALs;

    public partial class App : Application
    {
        IUnityContainer container = new UnityContainer();

        private void Application_Start(object sender, StartupEventArgs e)
        {
            this.RegisterObjectsWithUnity();

            var mainWindow = container.Resolve<SkypeghostShell>();
            mainWindow.Show();
        }

        private void RegisterObjectsWithUnity()
        {
            // DALs
            this.container.RegisterType<IClipboardAccessor, ClipboardAccessor>();

            // Models
            this.container.RegisterType<ISkypeghostModel, SkypeghostModel>();
        }
    }
}
