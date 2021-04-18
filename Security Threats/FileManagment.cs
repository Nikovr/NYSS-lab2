using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace Security_Threats
{
    public static class FileManagment
    {
        public static void Download(string url, string name)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.DownloadFile(url, name);
                }
            }
            catch (WebException)
            {
                MessageBox.Show("При скачивании файла произошла ошибка.\nПожалуйста, проверьте интернет соединение");
                Application.Current.MainWindow.Close();
            }
        }

        public static void Save(string text)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                File.WriteAllText(dlg.FileName, text);
            }
        }
        
    }
}
