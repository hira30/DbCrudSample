using Microsoft.Data.SqlClient;
using SQLServerApp;

// 先ほどコピーした接続文字列を貼り付ける
var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

// 実行するSQL
var sql = "SELECT * FROM Test";

// 接続のためのオブジェクトを生成
// 実行後にオブジェクトのCloseが必要なためusing文で囲う
using (var connection = new SqlConnection(connectionString))
{
    // 接続を確立
    connection.Open();

    // SqlCommand：DBにSQL文を送信するためのオブジェクトを生成
    // SqlDataReader：読み取ったデータを格納するためのオブジェクトを生成
    using (var command = new SqlCommand(sql, connection))
    using (var reader = command.ExecuteReader())
    {
        // 1行ごとに読み取る
        while (reader.Read())
        {
            // 列名を指定して、読み取ったデータをコンソール上に表示
            Console.WriteLine($"Name：{reader["Name"]}   Age：{reader["Age"]}   Birthday：{reader["Birthday"]}");
        }
    }
}

// 同期処理
//var sync = new CrudSync(connectionString);

//sync.Update();
//sync.Insert();
//sync.Delete();

//Console.WriteLine("処理が完了しました！");


// 非同期処理
var async = new CrudAsync(connectionString);

await async.UpdateAsync();
await async.InsertAsync();
await async.DeleteAsync();

Console.WriteLine("処理が完了しました！");