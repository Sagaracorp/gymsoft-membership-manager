using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            MySqlConnection oconn = new MySqlConnection("Server=gymsoft.db.10266153.hostedresource.com; Port=3306; Database=gymsoft; Uid=gymsoft; Pwd='G3tf!t12';");
            
            MySqlCommand command = oconn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "gym_sp_AuthenticateUser";
            command.Parameters.AddWithValue("buid", "1");
            command.Parameters.AddWithValue("uname", "vulputate,");
            command.Parameters.AddWithValue("pass", "Mauris");
            command.Parameters.Add(new MySqlParameter("@uid", MySqlDbType.Int32));
            command.Parameters["@uid"].Direction = ParameterDirection.Output;
            //command.Parameters.Add(new MySqlParameter("@result", MySqlDbType.VarChar, 12));
            command.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            command.Parameters["@result"].Direction = ParameterDirection.Output;
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            System.Console.WriteLine(command.Parameters["@uid"].Value.ToString() + " " + command.Parameters["@result"].Value.ToString());


            System.Threading.Thread.Sleep(5000);





        }




    }
}
