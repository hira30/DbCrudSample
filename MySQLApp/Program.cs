using MySqlConnector;

// 接続文字列
var connectionString = "Server=localhost;User ID=root;Password=1234;Database=test";

// 実行するSQL
var sql = "SELECT * FROM users";

using (var connection = new MySqlConnection(connectionString))
{
    // 接続の確立
    connection.Open();

    using (var command = new MySqlCommand(sql, connection))
    using (var reader = command.ExecuteReader())
    {
        // SELECT文を実行し、結果を1行ずつコンソールに表示
        while (reader.Read())
        {
            Console.WriteLine($"ID:{reader["id"]} 名前:{reader["name"]}　年齢:{reader["age"]}");
        }
    }
}