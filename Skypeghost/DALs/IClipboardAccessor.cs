namespace Skypeghost.DALs
{
    using System.Windows;

    public interface IClipboardAccessor
    {
        IDataObject GetClipboardData();

        void SetClipboardData(IDataObject data);
    }
}
