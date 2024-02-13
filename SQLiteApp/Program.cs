using Microsoft.Data.Sqlite; 

// 接続先情報（bin/Debugフォルダ内に「test.sqlite」という名前でDBが作成される）
var connectionString = "Data Source=test.sqlite";

// 接続やSQL実行に必要なインスタンスの生成
using (var connection = new SqliteConnection(connectionString))
using (var command = connection.CreateCommand())
{
    // 接続開始
    connection.Open();

    // usersテーブルの作成
    command.CommandText = @"CREATE TABLE users(id int, name varchar(10), age int)";
    command.ExecuteNonQuery();

    // データの挿入
    command.CommandText = @"
                    INSERT INTO users(id, name, age) VALUES(1, 'Mike', 30);
                    INSERT INTO users(id, name, age) VALUES(2, 'Lisa', 24);
                    INSERT INTO users(id, name, age) VALUES(3, 'Taro', 35);";
    command.ExecuteNonQuery();

    // SELECT文の実行
    command.CommandText = "SELECT * FROM users";
    using var reader = command.ExecuteReader();

    // 1行ずつデータを取得
    while (reader.Read())
    {
        Console.WriteLine($"ID:{reader["id"]}  名前:{reader["name"]}  年齢:{reader["age"]}");
    }
}
