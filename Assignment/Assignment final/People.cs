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
    class People
    {
        public static void LoadUser()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string fullName;
                    int id = 1;
                    string read;
                    double balance;
                    string cardNumber;

                    conn.ConnectionString = "Data Source=DARYLTEH\\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM People;";
                    cmd.ExecuteNonQuery();
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader People = new StreamReader("C:\\Users\\denis\\source\\repos\\P1841495_P1829316_1A24\\P1841495_P1829316_1A24\\Assignment\\people.txt");
                    read = People.ReadLine();
                    //Continue to read until you reach end of file
                    while ((read != null))
                    {
                        

                        read = People.ReadLine();
                        fullName = read;
                        read = People.ReadLine();
                        cardNumber = read;
                        read = People.ReadLine();
                        balance = Double.Parse(read);
                        read = People.ReadLine();


                        cmd.CommandText = "INSERT INTO People (Id,FullName,CardNumber,Balance)" +
                            "Values ('" + id + "','" + fullName + "','" + cardNumber + "','" + balance +"')";
                        cmd.ExecuteNonQuery();
                        id++;


                    }//Read people.txt and insert the data into Sql Table
                }
                conn.Close();
            }
            

        }

        
            

    }
}
