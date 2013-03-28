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
            DataSet ds = new DataSet();

            MySqlConnection oconn = new MySqlConnection("Server=gymsoft.db.10266153.hostedresource.com; Port=3306; Database=gymsoft; Uid=gymsoft; Pwd='G3tf!t12';");

            MySqlCommand command = oconn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "gym_sp_GetUsers";
            command.Parameters.AddWithValue("buid", "1");
            command.Parameters.AddWithValue("userid", "1");
            command.Parameters.Add(new MySqlParameter("@result", MySqlDbType.Int32));
            command.Parameters["@result"].Direction = ParameterDirection.Output;


            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = command;

            da.Fill(ds);

            //command.Connection.Open();
            //command.ExecuteNonQuery();
            //command.Connection.Close();

            PrintDataSet(ds);

            System.Threading.Thread.Sleep(2000);

            System.Console.WriteLine(command.Parameters["@result"].Value.ToString());


            System.Threading.Thread.Sleep(10000);
        }

        static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine("Tables in '{0}' DataSet.\n", ds.DataSetName);
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("{0} Table.\n", dt.TableName);
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Columns[curCol].ColumnName.Trim() + "\t");
                }
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Console.Write(dt.Rows[curRow][curCol].ToString().Trim() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
