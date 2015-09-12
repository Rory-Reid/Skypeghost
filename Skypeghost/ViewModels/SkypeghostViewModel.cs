namespace Skypeghost.ViewModels
{
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Mvvm;
    using Skypeghost.Models;
    using System;
    using System.Windows.Input;

    public class SkypeghostViewModel : BindableBase
    {
        private ISkypeghostModel model;

        private string userName;
        private string displayName;
        private string conversationName;
        private string quoteText;
        private DateTime timeStamp = DateTime.Now.ToUniversalTime();

        public SkypeghostViewModel(ISkypeghostModel model)
        {
            this.model = model;

            this.PasteClipboardData = new DelegateCommand(() => this.model.GetLatestClipboardData());
        }

        public ICommand PasteClipboardData { get; private set; }

        public string UserName
        {
            get { return this.userName; }
            set { this.SetProperty(ref this.userName, value); }
        }

        public string DisplayName
        {
            get { return this.displayName; }
            set { this.SetProperty(ref this.displayName, value); }
        }

        public string ConversationName
        {
            get { return this.conversationName; }
            set { this.SetProperty(ref this.conversationName, value); }
        }

        public string QuoteText
        {
            get { return this.quoteText; }
            set { this.SetProperty(ref this.quoteText, value); }
        }
    }
}
