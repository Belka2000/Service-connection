using DataBaseConnector.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnector
{
    public class DataBaseDriver
    {
        private static string _host = "127.0.0.1";
        private static string _user = "postgres";
        private static string _dbName = "postgres";
        private static string _password = "Mandarinka175";
        private static string _port = "5432";

        private static string _dropTable = "DROP TABLE IF EXISTS inventory";
        private static string _creatTable = "CREATE TABLE inventory(id serial PRIMARY KEY, name VARCHAR(50), quantity INTEGER)";
        private static string _insentTable = "INSERT INTO inventory (name, quantity) VALUES (@n1, @q1), (@n2, @q2), (@n3, @q3)";
        private static string _selectTable = "SELECT * FROM inventory";
        private static string _updateTable = "UPDATE inventory SET quantity = @q WHERE name = @n";
        private static string _deleteTable = "DELETE FROM inventory WHERE name = @n";
        
        

        static void Main(string[] args)
        {
            string connString =
             String.Format(
                 "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                 _host,
                 _user,
                 _dbName,
                 _port,
                 _password);

            using (var conn = new NpgsqlConnection(connString))

            {
                Console.Out.WriteLine("Opening connection");

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.ToString());
                }

                SqlCommand.DroppingTable(_dropTable ,conn);
                SqlCommand.CreatingTable(_creatTable ,conn);
                SqlCommand.InsertingTable(_insentTable, conn);
                SqlCommand.SelectingTable(_selectTable, conn);
                SqlCommand.UpdatingTable(_updateTable, conn);
                SqlCommand.DeletingTable(_deleteTable, conn);
                SqlCommand.SelectingTable(_selectTable, conn);
                
            }
        }
    }
}
