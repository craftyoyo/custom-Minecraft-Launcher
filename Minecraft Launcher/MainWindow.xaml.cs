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
using Microsoft.Win32;

namespace Minecraft_Launcher
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string JavaPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (string.IsNullOrEmpty(JavaPath))
            {
                MessageBox.Show("La variable d'environnement JAVA_HOME semble vide ou n'existe pas", "Java non détecté");
                MessageBox.Show("Java va être télécharger sous la version la plus récente", "Téléchargement de Java");

            }
            else
            {
                MessageBox.Show("Java semble installé", "Java");

            }

            InitializeComponent();
        }
    }
}
