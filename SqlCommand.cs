using DataBaseConnector.Models;
using Npgsql;


namespace DataBaseConnector
{
    public static class SqlCommand
    {
        public static void DroppingTable(string sql, NpgsqlConnection conn)
        {
            using (var command = new NpgsqlCommand(sql, conn))
            {
                command.ExecuteNonQuery();
                Console.Out.WriteLine("Finished dropping table (if existed)");
            }
        }

        public static void CreatingTable(string sql, NpgsqlConnection conn)
        {
            using (var command = new NpgsqlCommand(sql, conn))
            {
                command.ExecuteNonQuery();
                Console.Out.WriteLine("Finished creating table");
            }

        }

        public static void InsertingTable(string sql, NpgsqlConnection conn)
        {
            using (var command = new NpgsqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("n1", "banana");
                command.Parameters.AddWithValue("q1", 150);
                command.Parameters.AddWithValue("n2", "orange");
                command.Parameters.AddWithValue("q2", 154);
                command.Parameters.AddWithValue("n3", "apple");
                command.Parameters.AddWithValue("q3", 100);

                int nRows = command.ExecuteNonQuery();
                Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
            }
        }
        public static void UpdatingTable(string sql, NpgsqlConnection conn)
        {
            using (var command = new NpgsqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("n", "banana");
                Console.WriteLine("введите кол-во бананов");
                int amountbanana = int.Parse(Console.ReadLine());
                command.Parameters.AddWithValue("q", amountbanana);
                int nRows = command.ExecuteNonQuery();
                Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
            }
        }

        public static void DeletingTable(string sql, NpgsqlConnection conn)
        {
            using (var command = new NpgsqlCommand(sql, conn))
            {
                Console.WriteLine("введите какой продукт хотите удалить");
                string nameproduct = Console.ReadLine();
                if (nameproduct != "banana" || nameproduct != "orange" || nameproduct != "apple")
                    Console.WriteLine("вы ввели неверное наименование продукта");
                command.Parameters.AddWithValue("n", nameproduct);

                int nRows = command.ExecuteNonQuery();
                Console.Out.WriteLine(String.Format("Number of rows deleted={0}", nRows));
            }
        }

        public static void SelectingTable(string sql, NpgsqlConnection conn)
        {
            using (var command = new NpgsqlCommand(sql, conn))
            {
                // Инициализируем список Inventory
                List<Inventory> inventories = new List<Inventory>();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Inventory inventory = new Inventory();
                    inventory.Id = reader.GetInt32(0);
                    inventory.Name = reader.GetString(1);
                    inventory.Quantity = reader.GetInt32(2);
                    inventories.Add(inventory);
                }

                reader.Close();
                JsonCommand.ConvertToJson(inventories);
                //Console.ReadKey(); для выхода из консоли?
            }
        }


    }
}