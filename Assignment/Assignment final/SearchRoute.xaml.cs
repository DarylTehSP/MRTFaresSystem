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
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;



namespace Assignment_final
{
    /// <summary>
    /// Interaction logic for SearchRoute.xaml
    /// </summary>
    /// 
    public partial class SearchRoute : Window
    {
        static List<Line> trainLine = new List<Line>();
        static List<Guide> interchange = new List<Guide>();
        static Boolean checkedbox = false;

        public SearchRoute()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            this.Close();
        }

        private void Do_Checked(double fare, int useCard)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string starting=Start.Text, stopping=Stop.Text;
                    int id;
                    string today = DateTime.Today.ToString() ;
                    conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT COUNT(1) FROM Earnings";
                    cmd.ExecuteNonQuery();
                    id = int.Parse(cmd.ExecuteScalar().ToString())+1;
                    cmd.CommandText = "INSERT INTO Earnings (Id,Starting,Stopping,Fare,TheDay,UseCard)" +
                            "Values ('" + id + "','" + starting + "','" + stopping + "','" + fare + "','" + today + "','" + useCard +"')";
                        cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int i=1;
            string DepartStation = Start.Text;
            string AlightStation = Stop.Text;
            string departStationId="";
            string alightStationId="";
            string cardnumber = CardNo.Text;
            string CardFare="", FullFare="", duration="";
            if (Start.Text == "" || Stop.Text == "")
                Output.Text = "Invalid Input, Please re-enter the station or code";
            for (int x = 1; x <= DbGuide.Fares.Rows.Count - 1; x++)
            {
                i = x;
                if (DbGuide.Fares.Rows[x]["DepartStationName"].ToString() == DepartStation && DbGuide.Fares.Rows[x]["ArrivedStationName"].ToString() == AlightStation)
                {
                    CardFare = DbGuide.Fares.Rows[x]["CardFare"].ToString();
                    FullFare = DbGuide.Fares.Rows[x]["FullFare"].ToString();
                    duration = DbGuide.Fares.Rows[x]["Duration"].ToString();
                }
                if (i<142 && DbGuide.Station.Rows[i]["Name"].ToString() == DepartStation)
                {
                    departStationId =  DbGuide.Station.Rows[i]["Code"].ToString();
                }
                if (i<142 && DbGuide.Station.Rows[i]["Name"].ToString() == AlightStation)
                {
                    alightStationId = DbGuide.Station.Rows[i]["Code"].ToString();
                }
            }
            CardFare = CardFare.Substring(1,CardFare.Length-1);
            FullFare = FullFare.Substring(1,FullFare.Length-1);
            if (checkedbox)
            {
                Do_Checked(double.Parse(CardFare), 1);
            }
            else
            {
                Do_Checked(double.Parse(FullFare), 0);
            }
            Output.Text = "Start: "+DepartStation +" "+departStationId+"\nStop: "+AlightStation+" "+alightStationId+"\nCard fare: "+CardFare+"  Full fare: "+FullFare +"  Duration: "+duration+" minutes\n";
        }

        private void cbxCheck_Checked(object sender, RoutedEventArgs e)
        {
            checkedbox = true;
        }

        private void cbxCheck_Unchecked_1(object sender, RoutedEventArgs e)
        {
            checkedbox = false;
        }
    }
}