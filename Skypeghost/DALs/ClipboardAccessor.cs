namespace Skypeghost.DALs
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Windows;

    public class ClipboardAccessor : IClipboardAccessor
    {
        const string FormatText = "Text";
        const string FormatUnicodeText = "UnicodeText";
        const string FormatSystemString = "System.String";
        const string FormatSkypeMessageFragment = "SkypeMessageFragment";
        const string FormatLocale = "Locale";
        const string FormatOEMText = "OEMText";

        private readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public void GetClipboardData()
        {
            var data = Clipboard.GetDataObject();

            var msg = "Hello World!";
            var now = (DateTime.Now.ToUniversalTime() - epoch).TotalSeconds.ToString();
            var sanitisedTimestamp = now.Split('.')[0];

            var skypeMessageFragment = this.GenerateFragment(quoteText: msg, timestamp: sanitisedTimestamp);

            var dataobj = new DataObject();

            dataobj.SetData(FormatText, msg);
            dataobj.SetData(FormatUnicodeText, msg);
            dataobj.SetData(FormatSystemString, msg);
            dataobj.SetData(FormatSkypeMessageFragment, new MemoryStream(Encoding.UTF8.GetBytes(skypeMessageFragment)));
            dataobj.SetData(FormatLocale, new MemoryStream(BitConverter.GetBytes(CultureInfo.CurrentCulture.LCID)));
            dataobj.SetData(FormatOEMText, msg);

            Clipboard.Clear();
            Clipboard.SetDataObject(dataobj);
        }

        /// <summary>
        /// Generates the skype message
        /// </summary>
        /// <param name="authorUsername">Actual skype username of the person you are quoting</param>
        /// <param name="authorName">"Friendly" name of the person you are quoting. Whatever you see them listed as in contacts</param>
        /// <param name="conversationName">Name of the conversation (if conversation is 1-to-1, it's their username).</param>
        /// <param name="guid">A GUID. I don't know why. Make this one up?</param>
        /// <param name="timestamp">"Unix Time" style timestamp. Number of seconds since epoch.</param>
        /// <param name="quoteText">Actual text you are quoting</param>
        /// <returns>Evil incarnate</returns>
        private string GenerateFragment(
            string authorUsername = @"",
            string authorName = @"",
            string conversationName = @"",
            string guid = @"x1aeaa0c0ff5f590a168c09c7b7c9be8d05bb9d16382c000cd2bf6644f4029648",
            string timestamp = @"1441988888",
            string quoteText = @"Quote me, baby")
        {
            // Actual format of the XML message fragment, to be stored on the clipboard
            const string SkypeFragmentFormat = @"<quote author=""{0}"" authorname=""{1}"" conversation=""{2}"" guid=""{3}"" timestamp=""{4}""><legacyquote>{5}</legacyquote>{6}<legacyquote>{7}</legacyquote></quote>";

            // Format of the start of the legacy quote. Should be presented like "[01/01/2015 18:08:42] Randy Savage: " using timestamp & author name
            const string LegacyQuotePrefixFormat = @"[{0}] {1}: ";

            // I don't know what this does but I'll probably sanitise the string at some point rather than relying on the literal string format smh
            const string LegacyQuoteSuffix = @"

&lt;&lt;&lt; ";

            // this is horrible lmao
            var legacyQuotePrefix = string.Format(LegacyQuotePrefixFormat, epoch.AddSeconds(double.Parse(timestamp)).ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss"), authorName);

            return string.Format(
                SkypeFragmentFormat,
                authorUsername,
                authorName,
                conversationName,
                guid,
                timestamp,
                legacyQuotePrefix,
                quoteText,
                LegacyQuoteSuffix);
        }
    }
}
// todo: make this not horrible