namespace Skypeghost.ViewModels
{
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Mvvm;
    using Skypeghost.Models;
    using System.Windows.Input;

    public class SkypeghostViewModel : BindableBase
    {
        private ISkypeghostModel model;

        public SkypeghostViewModel(ISkypeghostModel model)
        {
            this.model = model;

            this.PasteClipboardData = new DelegateCommand(() => this.model.GetLatestClipboardData());
        }

        public ICommand PasteClipboardData { get; private set; }
    }
}
