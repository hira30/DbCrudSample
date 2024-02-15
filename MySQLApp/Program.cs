using MySqlConnector;

// 接続文字列
var connectionString = "Server=localhost;User ID=root;Password=1234;Database=test";

// 接続やSQL実行に必要なインスタンスの生成
using (var connection = new MySqlConnection(connectionString))
using (var command = connection.CreateCommand())
{
    // 接続の確立
    connection.Open();

    // usersテーブルが存在する場合は削除する
    command.CommandText = "DROP TABLE IF EXISTS users;";
    command.ExecuteNonQuery();

    // usersテーブルの作成
    command.CommandText = "CREATE TABLE users (id INTEGER, name VARCHAR(10), age INTEGER);";
    command.ExecuteNonQuery();
    
    // サンプルデータの登録
    command.CommandText = @"
                    INSERT INTO users (id, name, age) VALUES (1, 'Mike', 30);
                    INSERT INTO users (id, name, age) VALUES (2, 'Lisa', 24);
                    INSERT INTO users (id, name, age) VALUES (3, 'Taro', 35);";
    command.ExecuteNonQuery();

    // SELECT文の実行
    command.CommandText = "SELECT * FROM users;";
    using var reader = command.ExecuteReader();

    // 1行ずつデータを取得
    while (reader.Read())
    {
        Console.WriteLine($"ID:{reader["id"]}  名前:{reader["name"]}  年齢:{reader["age"]}");
    }
}