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
using System.IO;

namespace Assignment_final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            Line.LoadStation();
            DbGuide.LoadStation();
            DbGuide.LoadPeople();
            DbGuide.LoadLine();
            DbGuide.LoadFares();
            DbGuide.RunFares();
            People.LoadUser();
            InitializeComponent();
            lblinstruction.Content = "Click on SearchLine button to search the line of a station." +
                "\r\nStep 1: Enter the name or code of the station into the box." +
                "\r\nStep 2: Click on search button once you key in the station name or code" +
                "\r\nYou can tick the checkbox to show all the station in the line" +
                "\r\n\r\n" +
                "Click on the SearchRoute button to search the route from one station to another station." +
                "\r\nStep 1: Enter the name or code of the startpoint station to the box beside text startpoint and the name or code of the destination" +
                "\r\nstation in the box beside text destination." +
                "\r\nStep 2: Click on search button once you key in the station name. " +
                "\r\n\r\n" +
                "\r\nCreated by Daryl Teh and Jason Yeo ";
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchLine win2 = new SearchLine();
            win2.Show();
            this.Close();
        }
            
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SearchRoute win2 = new SearchRoute();
            win2.Show();
            this.Close();
        }

    }
}
