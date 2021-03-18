using System;

using System.IO;

using System.Text;


namespace TestFrameWork.Helpers
{
    /// <summary>
    /// Provides some wrappers for handling Files/Directory
    /// </summary>
    public static class Files
    {

        public static void CreateFolderIfDoesntExist(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }
        public static void WritePageSourceToHtmlFile(string filePath, string scenarioTitle, DateTime testExecutionStartTime, string textToWrite)
        {
            string path = string.Concat(filePath, ".html");
            using (var fs = new FileStream(path, FileMode.Create))
            {
                using (var w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.Write(textToWrite);
                }
            }
        }
    }
}
