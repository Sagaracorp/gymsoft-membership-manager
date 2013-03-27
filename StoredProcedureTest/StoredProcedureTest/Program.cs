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

            MySqlCommand MySqlCommand = oconn.CreateCommand();

            MySqlCommand.CommandType = CommandType.StoredProcedure;
            MySqlCommand.CommandText = "gym_sp_CreateNewUser";
            MySqlCommand.Parameters.AddWithValue("buid", 1);
            MySqlCommand.Parameters.AddWithValue("userid", 1);

            MySqlCommand.Parameters.AddWithValue("fname", "Dwayne");
            MySqlCommand.Parameters.AddWithValue("mname", "T");
            MySqlCommand.Parameters.AddWithValue("lname", "Williams");
            MySqlCommand.Parameters.AddWithValue("dob", "2012-01-01");
            MySqlCommand.Parameters.AddWithValue("email", "a@b.com");
            MySqlCommand.Parameters.AddWithValue("num1", "1234");
            MySqlCommand.Parameters.AddWithValue("num2", "1234");
            MySqlCommand.Parameters.AddWithValue("num3", "1234");
            MySqlCommand.Parameters.AddWithValue("add1", "1234");
            MySqlCommand.Parameters.AddWithValue("add2", "1234");
            MySqlCommand.Parameters.AddWithValue("add3", "1234");
            MySqlCommand.Parameters.AddWithValue("par", "1234");
            MySqlCommand.Parameters.AddWithValue("sex", "MALE");
            MySqlCommand.Parameters.AddWithValue("photo", "C:\\wert.jpg");
            MySqlCommand.Parameters.AddWithValue("uname", "draco");
            MySqlCommand.Parameters.AddWithValue("pwd", "iamtheone");
            MySqlCommand.Parameters.AddWithValue("status", "Active");
            MySqlCommand.Parameters.AddWithValue("jt", "boss");



            MySqlCommand.Parameters.Add(new MySqlParameter("@newUserId", MySqlDbType.Int32));
            MySqlCommand.Parameters["@newUserId"].Direction = ParameterDirection.Output;
            MySqlCommand.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            MySqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            MySqlCommand.Connection.Open();
            MySqlCommand.ExecuteNonQuery();
            MySqlCommand.Connection.Close();

            //return (int)MySqlCommand.Parameters["@newUserId"].Value;


            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "gym_sp_AuthenticateUser";
            //command.Parameters.AddWithValue("buid", "1");
            //command.Parameters.AddWithValue("uname", "vulputate,");
            //command.Parameters.AddWithValue("pass", "Mauris");
            //command.Parameters.Add(new MySqlParameter("@uid", MySqlDbType.Int32));
            //command.Parameters["@uid"].Direction = ParameterDirection.Output;
            ////command.Parameters.Add(new MySqlParameter("@result", MySqlDbType.VarChar, 12));
            //command.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            //command.Parameters["@result"].Direction = ParameterDirection.Output;
            //command.Connection.Open();
            //command.ExecuteNonQuery();
            //command.Connection.Close();

            System.Console.WriteLine(MySqlCommand.Parameters["@newUserId"].Value.ToString() + " " + MySqlCommand.Parameters["@result"].Value.ToString());


            System.Threading.Thread.Sleep(5000);





        }




    }
}
