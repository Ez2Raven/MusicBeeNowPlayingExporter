using System;
using System.Windows.Forms;

namespace MusicBeePlugin
{
    public class UIHelper
    {
        /// <summary>
        ///     Display a friendly message to the user when an exception occurs, also prompts the user to store the exception
        ///     message in the clipboard for easier reporting.
        /// </summary>
        /// <param name="friendlyMessage"></param>
        /// <param name="exception"></param>
        /// <returns><see cref="DialogResult" /> for addition processing if required</returns>
        public static DialogResult DisplayExceptionDialog(Exception exception, string friendlyMessage = null)
        {
            if (string.IsNullOrWhiteSpace(friendlyMessage)) friendlyMessage = "Oops, Something unexpected happened.";

            var shouldStoreExceptionInClipboard = MessageBox.Show(
                $@"{friendlyMessage} {Environment.NewLine} 
                     If you can't resolve this on your own, please report an issue at https://github.com/demandous/MusicBeeNowPlayingExporter {Environment.NewLine} 
                     {exception.Message}");

            return shouldStoreExceptionInClipboard;
        }

        public static DialogResult DisplayMessageDialog(string friendlyMessage)
        {
            var userDialogInput = MessageBox.Show(friendlyMessage);
            return userDialogInput;
        }
    }
}