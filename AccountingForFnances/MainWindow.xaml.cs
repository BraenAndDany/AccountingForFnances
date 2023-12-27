using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingForFnances
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public int list_lenght = 0;
        public int i = -1000000000;
        
        public MainWindow()
        {
            InitializeComponent();
            FileInfo file = new FileInfo("C:\\Users\\qctm0\\Downloads\\otchet.txt");
        }
        private void Add(object sender, RoutedEventArgs e)
        {

            try
            {
                score.Content =Convert.ToInt32(score.Content)+Convert.ToInt32(Change.Text);
                if(Convert.ToInt32(score.Content)<0)
                {
                    error.Content = "Превышение бюджета";
                    add.Visibility = Visibility.Hidden;
                    remove.Visibility = Visibility.Hidden;
                }
                else
                {
                    if (Convert.ToInt32(stringnumb.Text)<=list_lenght)
                    {
                    
                        if(int.TryParse(Change.Text,out i))
                        {
                           list.Items.Insert(Convert.ToInt32(stringnumb.Text), Name.Text+" "+Change.Text);
                        }
                    
                    }
                    else
                    {
                        if (int.TryParse(Change.Text, out i))
                        {
                            list.Items.Insert(list_lenght, Name.Text + " " + Change.Text);
                        }
                        list_lenght++; 
                    }
                }
            } 
            catch 
            {

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                list.Items.RemoveAt(Convert.ToInt32(stringnumb.Text)-1);
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            score.Content=limbox.Text;
            list.Items.Clear();
            add.Visibility = Visibility.Visible;
            remove.Visibility = Visibility.Visible;
        }

        private async void otchet_Click(object sender, RoutedEventArgs e)
        {
            string path = "C:\\Users\\qctm0\\Downloads\\otchet.txt";
            string text = "";
            text=Convert.ToString(score.Content) + "\n";
            for (int i=0;i<list.Items.Count;i++)
            {
                text+=list.Items[i]+"\n";
            }
            await File.WriteAllTextAsync(path,text);
        }
    }
}