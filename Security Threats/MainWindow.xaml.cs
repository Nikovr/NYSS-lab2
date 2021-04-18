using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Security_Threats
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data data;
        private bool isShrinked;
        private PagingCollectionView view;
        public MainWindow()
        {
            InitializeComponent();

            if (!File.Exists("thrlist.xlsx"))
            {
                FileManagment.Download("https://bdu.fstec.ru/files/documents/thrlist.xlsx", "thrlist.xlsx");
            }

            data = new Data("thrlist.xlsx");
            
            view = new PagingCollectionView(data.Source, 15);
            DataContext = view;
            

        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            view.MoveToNextPage();
        }

        private void Previous_Button_Click(object sender, RoutedEventArgs e)
        {
            view.MoveToPreviousPage();

        }
        private void Shrink_Button_Click(object sender, RoutedEventArgs e)
        {
            if (data != null)
            {
                if (!isShrinked)
                {
                    view = new PagingCollectionView(Data.Shrink(data.Source), 15);
                    DataContext = view;

                    for (int i = 2; i < 8; i++)
                    {
                        dataGrid.Columns[i].Visibility = Visibility.Hidden;
                    }
                    ((Button)sender).Content = "Полный вид";
                    isShrinked = true;
                }
                else
                {
                    view = new PagingCollectionView(data.Source, 15);
                    DataContext = view;

                    for (int i = 2; i < 8; i++)
                    {
                        dataGrid.Columns[i].Visibility = Visibility.Visible;
                    }
                    ((Button)sender).Content = "Сокращенный вид";
                    isShrinked = false;
                }
            }
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            Data oldData = data;
            FileManagment.Download("https://bdu.fstec.ru/files/documents/thrlist.xlsx", "thrlist.xlsx");
            data = new Data("thrlist.xlsx");
            view = new PagingCollectionView(data.Source, 15);
            DataContext = view;
            Data.Compare(data, oldData);
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            FileManagment.Save(Data.ToText(data.Source));
        }
    }
}

