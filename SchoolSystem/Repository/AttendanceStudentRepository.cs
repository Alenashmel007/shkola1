using MySql.Data.MySqlClient;
using SchoolSystem.Infrastructure;
using SchoolSystem.Model;
using System.Data;

namespace SchoolSystem.Repository;

public class AttendanceStudentRepository
{
    /// <summary>
    /// Добавляет запись о посещаемости студента в базу данных.
    /// </summary>
    /// <param name="attendance">Модель посещаемости, содержащая информацию для добавления.</param>
    /// <returns>Возвращает true, если запись успешно добавлена; иначе false.</returns>
    public bool AddAttendance(AttendanceStudentModel attendance)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = @"INSERT INTO `Посещаемость` (`ID Студента`, `Посещение`, `Дата`)
                         VALUES (@StudentId, @IsAttendance, @AttendanceDate);";

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@StudentId", attendance.StudentId);
            command.Parameters.AddWithValue("@IsAttendance", attendance.IsAttendance);
            command.Parameters.AddWithValue("@AttendanceDate", attendance.AttendanceDate);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        catch (MySqlException sqlEx)
        {
            MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    /// <summary>
    /// Обновляет запись о посещаемости студента в базе данных.
    /// </summary>
    /// <param name="attendance">Модель посещаемости, содержащая обновленную информацию.</param>
    /// <returns>Возвращает true, если запись успешно обновлена; иначе false.</returns>
    public bool UpdateAttendance(AttendanceStudentModel attendance)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = @"UPDATE `Посещаемость`
                         SET `ID Студента` = @StudentId,
                             `Посещение` = @IsAttendance,
                             `Дата` = @AttendanceDate
                         WHERE `ID Посещаемости` = @AttendanceStudentId;";

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@StudentId", attendance.StudentId);
            command.Parameters.AddWithValue("@IsAttendance", attendance.IsAttendance);
            command.Parameters.AddWithValue("@AttendanceDate", attendance.AttendanceDate);
            command.Parameters.AddWithValue("@AttendanceStudentId", attendance.AttendanceStudentId);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        catch (MySqlException sqlEx)
        {
            MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    /// <summary>
    /// Удаляет запись о посещаемости студента из базы данных.
    /// </summary>
    /// <param name="attendanceStudentId">Идентификатор записи посещаемости для удаления.</param>
    /// <returns>Возвращает true, если запись успешно удалена; иначе false.</returns>
    public bool DeleteAttendance(int attendanceStudentId)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = "DELETE FROM `Посещаемость` WHERE `ID Посещаемости` = @AttendanceStudentId;";
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@AttendanceStudentId", attendanceStudentId);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        catch (MySqlException sqlEx)
        {
            MessageBox.Show($"Ошибка базы данных: {sqlEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    public DataTable GetAttendanceStudent()
    {
        string query = @"
        SELECT `ID Посещаемости`, п.`ID Студента`, `Посещение`, `Дата`, CONCAT(Фамилия,' ',Имя,' ',Отчество) AS Студент
        ,гр.`Наименование` AS Группа
        FROM `Посещаемость` п
        INNER JOIN `Студенты` с on с.`ID Студента` = п.`ID Студента`
        INNER JOIN `Группы` гр on гр.`ID Группы` = с.`ID Группы`";

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
