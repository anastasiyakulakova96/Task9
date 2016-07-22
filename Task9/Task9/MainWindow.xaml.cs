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
using System.Reflection;



namespace Task9
{
   
    public partial class MainWindow : Window
    {
       string selectName;
        public Type a;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_ClickSelectDirectory(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            tbPath.Text = fbd.SelectedPath;
            
        }

        private void bSelectFiles_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(tbPath.Text);
            List<FileInfo> files = di.GetFiles("*.dll").ToList();
            var fileNames = files.Select(f => lbFiles.Items.Add(f.Name)).ToList();
                                 
        }

        private void lbFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectName = lbFiles.SelectedItem.ToString();
            string path = tbPath.Text + "/" + selectName;
            Assembly assembly = Assembly.LoadFile(path);
         a=assembly.GetType();
        }

        private void lbtypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbtypes.TextInput(a);
        }
    }
}
