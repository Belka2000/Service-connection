using DataBaseConnector.Models;
using Newtonsoft.Json;

namespace DataBaseConnector
{
    public class JsonCommand
    {
        public static void ConvertToJson(List<Inventory> inventories)
        {
            string json = JsonConvert.SerializeObject(inventories, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
