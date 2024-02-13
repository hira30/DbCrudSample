using Microsoft.Data.SqlClient;

namespace SQLServerApp
{
    internal class CrudAsync(string connectionString)
    {
        /// <summary>
        /// Update文を実行するメソッド
        /// </summary>
        public async Task UpdateAsync()
        {
            // IDが2のレコードのAgeを50に更新する
            var updateQuery = "UPDATE Test SET Age = 50 WHERE Id = 2";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(updateQuery, connection))
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// Insert文を実行するメソッド
        /// </summary>
        public async Task InsertAsync()
        {
            // パラメーターで中身を指定したレコードを追加
            var insertQuery = @"INSERT INTO Test(Id, Name, Age, Birthday) VALUES (@id, @name, @age, @birthday)";
            var name = "Nancy";
            var age = "28";
            var birthday = "1993/5/5";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(insertQuery, connection))
            {
                await connection.OpenAsync();

                // パラメーターの追加
                command.Parameters.AddWithValue("@id", 4);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@birthday", birthday);

                await command.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// Delete文を実行するメソッド
        /// </summary>
        public async Task DeleteAsync()
        {
            // Idが3のレコードを削除
            var deleteQuery = "DELETE FROM Test WHERE Id = 3";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(deleteQuery, connection))
            {
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
