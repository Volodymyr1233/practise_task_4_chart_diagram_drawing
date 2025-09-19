using Microsoft.Data.SqlClient;
using System.IO;

namespace StatisticsWebApp.Models

{
    public class DatabaseConnection
    {
        private readonly string connectionString;

        public DatabaseConnection(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionData");
        }

        public void InsertDiagram(List<int> stats_nums)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string stats_nums_str = string.Join(",", stats_nums);
                byte[] image_bytes = File.ReadAllBytes(GlobalImagePath.img_path);
                string query = "INSERT INTO Charts (Integers_list, Img) VALUES (@stats_nums, @img)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@stats_nums", stats_nums_str);
                    command.Parameters.AddWithValue("@img", image_bytes);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
