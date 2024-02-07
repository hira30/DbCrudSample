using Npgsql;

// 接続文字列
var connectionString =
"Server=localhost;Port=5432;Username=postgres;Password=1234;Database=test";

// 実行するSQL
var sql = "SELECT * FROM users";

// DB操作に必要なインスタンスを生成
using (var connection = new NpgsqlConnection(connectionString))
using (var command = new NpgsqlCommand(sql, connection))
{
    try
    {
        // 接続開始
        connection.Open();

        // SELECT文の実行
        using (var reader = command.ExecuteReader())
        {
            // 1行ずつ読み取ってコンソールに表示
            while (reader.Read())
            {
                Console.WriteLine($"ID:{reader["id"]} 名前:{reader["name"]}　年齢:{reader["age"]}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}