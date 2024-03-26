
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace MLBNotificationService
{
    public static class FileHelper
    {
        /// <summary>
        /// This is method a file can be read in to a list of strings
        /// </summary>
        /// <param name="file">Name of the file to load</param>
        /// <returns>The file as a string</returns>
        /// <exception>Will re-throw any exception it encounters</exception>
        static public List<string> TextFileToList(string file)
        {
            List<string> result = new();
            //make sure the file exists
            if (File.Exists(file))
            {
                try
                {
                    string data = File.ReadAllText(file);
                    string[] sdata = data.Replace('\n', ' ').Trim().Split('\r');
                    result.AddRange(sdata.Where(str => !string.IsNullOrEmpty(str)));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return result;
        }
    }
}
