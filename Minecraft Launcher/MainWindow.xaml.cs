using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Microsoft.Win32;

namespace Minecraft_Launcher
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void download(string URL, string path)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(URL, path);
            
        }

        public MainWindow()
        {
            if (!string.IsNullOrEmpty(GetJavaInstallationPath()))
            {
                MessageBox.Show("La variable d'environnement JAVA_HOME semble vide ou n'existe pas", "Java non détecté");
                MessageBox.Show("Java va être télécharger sous la version la plus récente", "Téléchargement de Java");

               /* string UserProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string DownloadFolder = UserProfile + "\\Downloads";
               */

            }
            else
            {
                MessageBox.Show("Java semble installé", "Java");
                MessageBox.Show(GetJavaInstallationPath(), "");
            }

            InitializeComponent();
        }

        static string GetJavaInstallationPath()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath;
            }

            const string JAVA_KEY = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";

            var localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
            using (var rk = localKey.OpenSubKey(JAVA_KEY))
            {
                if (rk != null)
                {
                    string currentVersion = rk.GetValue("CurrentVersion").ToString();
                    using (var key = rk.OpenSubKey(currentVersion))
                    {
                        return key.GetValue("JavaHome").ToString();
                    }
                }
            }

            localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            using (var rk = localKey.OpenSubKey(JAVA_KEY))
            {
                if (rk != null)
                {
                    string currentVersion = rk.GetValue("CurrentVersion").ToString();
                    using (var key = rk.OpenSubKey(currentVersion))
                    {
                        return key.GetValue("JavaHome").ToString();
                    }
                }
            }

            return null;
        }
    }


}


