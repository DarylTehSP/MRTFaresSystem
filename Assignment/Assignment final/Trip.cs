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
    class Trip
    {
        public static void AddTrip()
        {
            string DepartInput="";
            string ArrivedInput="";
            string CardNumber="";
            string Fare = "";
            int counter = 1;
            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO Trip (Id,DepartStationId,ArrivedStationId,UseCard,Fare)" +
                    "Values ('" + counter + "','" + DepartInput + "','" + ArrivedInput + "','" + CardNumber + "','" + Fare + "')";
                    cmd.ExecuteNonQuery();
                    counter++;
                }
                conn.Close();
            }


        }




    }
}