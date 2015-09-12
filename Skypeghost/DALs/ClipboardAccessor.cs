namespace Skypeghost.DALs
{
    using System.Windows;

    public class ClipboardAccessor : IClipboardAccessor
    {
        public IDataObject GetClipboardData()
        {
            return Clipboard.GetDataObject();
        }

        public void SetClipboardData(IDataObject data)
        {
            // Keep it on the clipboard when Skypeghost exits. Easier debugging.
            Clipboard.SetDataObject(data, true);
        }
    }
}
