using Microsoft.Data.SqlClient;

namespace SQLServerApp
{
    internal class CrudSync(string connectionString)
    {
        /// <summary>
        /// Update文を実行するメソッド
        /// </summary>
        public void Update()
        {
            // IDが2のレコードのAgeを50に更新する
            var updateQuery = "UPDATE Test SET Age = 50 WHERE Id = 2";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(updateQuery, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Insert文を実行するメソッド
        /// </summary>
        public void Insert()
        {
            // パラメーターで中身を指定したレコードを追加
            var insertQuery = @"INSERT INTO Test(Id, Name, Age, Birthday) VALUES (@id, @name, @age, @birthday)";
            var name = "Nancy";
            var age = "28";
            var birthday = "1993/5/5";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(insertQuery, connection))
            {
                connection.Open();

                // パラメーターの追加
                command.Parameters.AddWithValue("@id", 4);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@birthday", birthday);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Delete文を実行するメソッド
        /// </summary>
        public void Delete()
        {
            // Idが3のレコードを削除
            var deleteQuery = "DELETE FROM Test WHERE Id = 3";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(deleteQuery, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
