using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Assignment_final
{
    class DbGuide
    {
        
        public static DataTable Station = new DataTable();
        public static DataTable People = new DataTable();
        public static DataTable Line = new DataTable();
        public static DataTable Fares = new DataTable();
        public static DataTable Earnings = new DataTable();

        public static void LoadEarnings()
        {
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {

                            conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT * FROM Earnings";
                            da.SelectCommand = cmd;
                            da.Fill(DbGuide.Earnings);
                            //Populate the FareDataTable by loading tblFare table in Sql Database



                            conn.Close();
                        }//end of using da
                    }//end of using cmd
                }//end of using conn
            }
        }

        public static void LoadStation()
        {
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {

                            conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT * FROM Station";
                            da.SelectCommand = cmd;
                            da.Fill(DbGuide.Station);
                            //Populate the stationDataTable by loading tblStn in Sql Database


                            conn.Close();
                        }//end of using da
                    }//end of using cmd
                }//end of using conn
            }
        }
        public static void LoadLine()
        {
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {

                            conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT * FROM Line";
                            da.SelectCommand = cmd;
                            da.Fill(DbGuide.Line);
                            //Populate the LineDataTable by loading Line table in Sql Database



                            conn.Close();
                        }//end of using da
                    }//end of using cmd
                }//end of using conn
            }
        }
        public static void LoadPeople()
        {
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {

                            conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT * FROM People";
                            da.SelectCommand = cmd;
                            da.Fill(DbGuide.People);
                            //Populate the InterDataTable by loading tblInter table in Sql Database



                            conn.Close();
                        }//end of using da
                    }//end of using cmd
                }//end of using conn
            }
        }
        public static void RunFares()
        {
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {

                            conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.CommandText = "SELECT * FROM Fares";
                            da.SelectCommand = cmd;
                            da.Fill(DbGuide.Fares);
                            //Populate the FareDataTable by loading tblFare table in Sql Database



                            conn.Close();
                        }//end of using da
                    }//end of using cmd
                }//end of using conn
            }
        }

        public static void LoadFares()
        {

            string DepartStation = "";
            string ArriveStation = "";
            string a = "";
            string DepartStationName = "";
            string ArriveStationName = "";
            string CardFare = "";
            string FullFare = "";
            int Duration = 0;
            int Counter = 1;
            string b = "";
            string read;
            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM Fares;";
                    cmd.ExecuteNonQuery();
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader Fares = new StreamReader("C:\\Users\\denis\\source\\repos\\P1841495_P1829316_1A24\\P1841495_P1829316_1A24\\Assignment\\fares.txt");

                    read = Fares.ReadLine();
                    //Continue to read until you reach end of file
                    while ((read != null))
                    {
                        DepartStation = read.Substring(0, read.IndexOf(" "));
                        if (DepartStation.Contains("/"))
                        {
                            a = DepartStation.Substring(DepartStation.IndexOf("/") + 1);
                            DepartStation = DepartStation.Substring(0, DepartStation.IndexOf("/"));
                        }
                        if (a.Contains("/"))
                        {
                            b = a.Substring(a.IndexOf("/") + 1);
                            a = a.Substring(0, a.IndexOf("/"));

                        }
                        ArriveStation = read.Substring(read.IndexOf(" ") + 1);
                        if (ArriveStation.Contains("/"))
                        {
                            a = ArriveStation.Substring(0, ArriveStation.IndexOf("/"));
                            ArriveStation = ArriveStation.Substring(ArriveStation.IndexOf("/") + 1);
                        }
                        if (a.Contains("/"))
                        {
                            b = a.Substring(a.IndexOf("/") + 1);
                            a = a.Substring(0, a.IndexOf("/"));

                        }

                        read = Fares.ReadLine();
                        CardFare = read;
                        read = Fares.ReadLine();
                        FullFare = read;
                        read = Fares.ReadLine();
                        Duration = Int32.Parse(read);
                        read = Fares.ReadLine();

                        for (int x = 1; x <= DbGuide.Station.Rows.Count-1 ; x++)
                        {
                            if (DbGuide.Station.Rows[x]["Code"].ToString() == DepartStation)
                            {
                                DepartStationName = DbGuide.Station.Rows[x]["Name"].ToString();
                            }
                        }
                        for (int x = 1; x <= DbGuide.Station.Rows.Count-1; x++)
                        {
                            if (DbGuide.Station.Rows[x]["Code"].ToString() == ArriveStation)
                            {
                                ArriveStationName = DbGuide.Station.Rows[x]["Name"].ToString();
                            }
                        }


                        cmd.CommandText = "INSERT INTO Fares (Id,DepartStationName,ArrivedStationName,CardFare,FullFare,Duration)" +
                            "Values ('" + Counter + "','" + DepartStationName + "','" + ArriveStationName + "','" + CardFare + "','" + FullFare + "','" + Duration + "')";
                        cmd.ExecuteNonQuery();
                        Counter++;


                    }//Read fares.txt and insert the data into Sql Table


                    conn.Close();



                }
                
            }
        }
    }
}