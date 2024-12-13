using MySql.Data.MySqlClient;
using SchoolSystem.Infrastructure;
using System.Data;

namespace SchoolSystem.Repository;

public class StudentRepository
{
    public DataTable GetStudents()
    {
        string query = @"SELECT *, CONCAT(Фамилия,' ',Имя,' ',Отчество) AS 'Студент ФИО' FROM Студенты;";

        DataTable dataTable = new();

        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            using MySqlCommand command = new(query, connection);
            using MySqlDataAdapter adapter = new(command);

            adapter.Fill(dataTable);
        }
        catch (MySqlException sqlEx)
        {
            MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new DataTable();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new DataTable();
        }

        return dataTable;
    }
}
