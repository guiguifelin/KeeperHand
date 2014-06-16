using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Microsoft.Xna.Framework;
using System.ComponentModel;

namespace Game
{
    public class FTP
    {
        // Fields.
        private static bool complete = false, update = false;
        private static WebClient webClient;

        // Methods.
        public static void getHttpVersion()
        {
            webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DataDownloadComplete);
            Uri maj = new Uri("http://keeperhand.epimeros.org/server/version.txt");
            webClient.DownloadFileAsync(maj, Environment.CurrentDirectory + "\\Data\\version.txt");
        }
        public static void getHttpUpdate()
        {
            webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DataDownloadCompleteUpdate);
            Uri maj = new Uri("http://keeperhand.epimeros.org/server/Update.zip");
            webClient.DownloadFileAsync(maj, Environment.CurrentDirectory + "\\Data\\Update.zip");
        }
        public static string getVersion()
        {
            return File.ReadAllText(Environment.CurrentDirectory + "\\Data\\version.txt");
        }
        public static void DataDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            webClient.Dispose();
            complete = true;
        }
        public static void DataDownloadCompleteUpdate(object sender, AsyncCompletedEventArgs e)
        {
            webClient.Dispose();
            update = true;
        }
        public static bool UpdatedFile()
        {
            return update;
        }
        public static bool Update()
        {
            return complete;
        }
    }
}
