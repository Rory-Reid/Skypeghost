namespace Skypeghost.Views
{
    using Skypeghost.ViewModels;
    using System.Windows;

    public partial class SkypeghostShell : Window
    {
        public SkypeghostShell(SkypeghostViewModel vm)
        {
            this.InitializeComponent();

            this.DataContext = vm;
        }
    }
}
