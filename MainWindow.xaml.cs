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
using System.Windows.Forms;
using System.IO;

namespace RadiationRate.DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selectedLogFolder;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFolderButton_Click(object sender, RoutedEventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
                DialogResult result = folderDialog.ShowDialog();
                
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    selectedLogFolder = folderDialog.SelectedPath;
                    System.Windows.Forms.MessageBox.Show(selectedLogFolder);
                }
            }
        }

        private void MainPanel_Drop(object sender, System.Windows.DragEventArgs e)
        {
            List<string> filepaths = new List<string>();
            foreach (var s in (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop, false))
            {
                if (Directory.Exists(s))
                {
                    //Add files from folder
                    filepaths.AddRange(Directory.GetFiles(s));
                }
                else
                {
                    //Add filepath
                    filepaths.Add(s);
                }
            }

            System.Windows.Forms.MessageBox.Show(string.Join(Environment.NewLine, filepaths));
        }
    }
}
