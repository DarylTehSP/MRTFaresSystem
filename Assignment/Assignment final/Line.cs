using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Assignment_final
{
    class Line
    {
        public static List<Station> Stations; // Static List instance
        public static List<Line> Lines;
        static Line()
        {
            Lines = new List<Line>();
            Stations = new List<Station>();
        }

        public static void LoadStation()
        {
            string name = "";
            string code = "";
            string read;
            int Stationcounter = 0;
            int Linecounter = 0;
            string Linename = "";
            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM Station;";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM Line;";
                    cmd.ExecuteNonQuery();
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader list = new StreamReader("C:\\Users\\denis\\source\\repos\\P1841495_P1829316_1A24\\P1841495_P1829316_1A24\\Assignment\\list.txt");

                    read = list.ReadLine();
                    //Continue to read until you reach end of file
                    while ((read != null))
                    {
                        if (string.Equals(read, "(start)"))
                        {
                            Linecounter++;
                            read = list.ReadLine();
                            if (read.Contains("CC"))
                            {
                                Linename = "Circle Line";
                            }
                            else if (read.Contains("DT"))
                            {
                                Linename = "Downtown Line";
                            }
                            else if (read.Contains("EW"))
                            {
                                Linename = "East West Line";
                            }
                            else if (read.Contains("NS"))
                            {
                                Linename = "North South Line";
                            }
                            else if (read.Contains("CG"))
                            {
                                Linename = "East West Line(CG)";
                            }
                            else if (read.Contains("NE"))
                            {
                                Linename = "North East Line";
                            }
                            cmd.CommandText = "INSERT INTO Line (Id,Name)" +
                            "Values ('" + Linecounter + "','" + Linename + "')";
                            cmd.ExecuteNonQuery();
                        }
                        else if (string.Equals(read, "(end)"))
                        {
                            read = list.ReadLine();
                        }
                        else
                        {
                            code = read;
                            read = list.ReadLine();
                            name = read;
                            Stationcounter++;
                            read = list.ReadLine();
                            cmd.CommandText = "INSERT INTO Station (Id,LineId,Code,Name)" +
                            "Values ('" + Stationcounter + "','" + Linecounter + "','" + code + "','" + name + "')";
                            cmd.ExecuteNonQuery();

                        }
                    }

                }

                conn.Close();
            }
        }

    }

}