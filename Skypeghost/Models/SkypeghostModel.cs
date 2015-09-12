namespace Skypeghost.Models
{
    using Skypeghost.DALs;

    public class SkypeghostModel : ISkypeghostModel
    {
        private IClipboardAccessor clipboardAccessor;

        public SkypeghostModel(IClipboardAccessor clipboardAccessor)
        {
            this.clipboardAccessor = clipboardAccessor;
        }

        public void GetLatestClipboardData()
        {
            this.clipboardAccessor.GetClipboardData();
        }
    }
}
