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
using System.Windows.Shapes;
using System.IO;
using System.Data.SqlClient;

namespace Assignment_final
{
    /// <summary>
    /// Interaction logic for SearchLine.xaml
    /// </summary>
    public partial class SearchLine : Window
    {

        public SearchLine()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int lineId=0,x,i;
            string lineName="", output="";
            Boolean lineDone;
            if (txtName.Text == "")
            {
                tbxOutput.Text = "Invalid Input, Please re-enter the station or code";
            }
            else
            {
                for (x = 0; x <= DbGuide.Station.Rows.Count - 1; x++)
                {
                    lineDone = false;
                    if (DbGuide.Station.Rows[x]["Name"].ToString() == txtName.Text)//find the line ids in the station table for a valid station
                    {
                        if (output != "")
                            output += "\n\n";
                        lineId = int.Parse(DbGuide.Station.Rows[x]["LineId"].ToString());
                        lineName = DbGuide.Line.Rows[lineId - 1]["Name"].ToString();//get corresponding line name using lineId in line table; lineId=1 so lineName = circle line
                        output += lineName + "\n";
                        for (i = 0; i <= DbGuide.Station.Rows.Count - 1; i++)//loop thru stations to get the list of stations in the line
                        {
                            if (int.Parse(DbGuide.Station.Rows[i]["LineId"].ToString()) == lineId)
                            {
                                output += DbGuide.Station.Rows[i]["Name"].ToString() + ", ";//append all the station names into a string

                            }
                        }
                    }
                    lineId = lineId++;
                }
                tbxOutput.Text = output;
            }
        }
    }
}
