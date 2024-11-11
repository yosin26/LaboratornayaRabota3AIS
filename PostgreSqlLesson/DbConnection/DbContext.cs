using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace PostgreSqlLesson.DbConnection
{
    public class DbContext
    {
        // Строка подключения к базе данных
        private readonly string sqlconString = "Server=localhost;Port=5432;Database=Geese;Username=postgres;Password=12358";

        // Метод для инициализации базы данных (выполнение команд, не возвращающих данные)
        public void DatabaseInit(string query)
        {
            try
            {
                using (NpgsqlConnection sqlConnection = new NpgsqlConnection(sqlconString))
                {
                    sqlConnection.Open(); // Открытие соединения
                    using (var cmd = new NpgsqlCommand(query, sqlConnection))
                    {
                        cmd.ExecuteNonQuery(); // Выполнение запроса
                    }
                }
            }
            catch (Exception ex)
            {
                // Показываем ошибку пользователю
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
            }
        }

        // Метод для выполнения запросов, возвращающих данные (например, SELECT)
        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(sqlconString))
                {
                    connection.Open(); // Открытие соединения
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable); // Заполнение DataTable результатами запроса
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Показываем ошибку, если запрос не удался
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}");
            }

            return dataTable;
        }



    }
}
