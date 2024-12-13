using MySql.Data.MySqlClient;
using SchoolSystem.Infrastructure;
using SchoolSystem.Model;
using System.Data;

namespace SchoolSystem.Repository;

public class BallRepository
{
    /// <summary>
    /// Добавляет новую оценку в базу данных.
    /// </summary>
    /// <param name="grade">Модель оценки, содержащая информацию для добавления.</param>
    /// <returns>Возвращает true, если оценка успешно добавлена; иначе false.</returns>
    public bool AddGrade(BallStudentModel grade)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = @"INSERT INTO `Оценки` (`ID Предмета`, `ID Студента`, `Дата оценки`, `Оценка`)
                         VALUES (@SubjectId, @StudentId, @GradeDate, @GradeValue);";

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@SubjectId", grade.SubjectId);
            command.Parameters.AddWithValue("@StudentId", grade.StudentId);
            command.Parameters.AddWithValue("@GradeDate", grade.GradeDate);
            command.Parameters.AddWithValue("@GradeValue", grade.GradeValue);

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
    /// Обновляет существующую оценку в базе данных.
    /// </summary>
    /// <param name="grade">Модель оценки, содержащая обновленную информацию.</param>
    /// <returns>Возвращает true, если оценка успешно обновлена; иначе false.</returns>
    public bool UpdateGrade(BallStudentModel grade)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = @"UPDATE `Оценки`
                         SET `ID Предмета` = @SubjectId,
                             `ID Студента` = @StudentId,
                             `Дата оценки` = @GradeDate,
                             `Оценка` = @GradeValue
                         WHERE `ID Оценки` = @GradeId;";

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@SubjectId", grade.SubjectId);
            command.Parameters.AddWithValue("@StudentId", grade.StudentId);
            command.Parameters.AddWithValue("@GradeDate", grade.GradeDate);
            command.Parameters.AddWithValue("@GradeValue", grade.GradeValue);
            command.Parameters.AddWithValue("@GradeId", grade.GradeId);

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
    /// Удаляет оценку из базы данных.
    /// </summary>
    /// <param name="gradeId">Идентификатор оценки для удаления.</param>
    /// <returns>Возвращает true, если оценка успешно удалена; иначе false.</returns>
    public bool DeleteGrade(int gradeId)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = "DELETE FROM `Оценки` WHERE `ID Оценки` = @GradeId;";
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@GradeId", gradeId);

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
    /// Возвращает данные об оценках студентов, включая дату оценки, предмет и информацию о студенте.
    /// </summary>
    /// <returns>Объект DataTable с результатами выборки.</returns>
    public DataTable GetGrades()
    {
        string query = @"
        SELECT о.`Оценка`, о.`Дата оценки`, п.`Наименование` AS 'Предмет'
               ,о.`ID Оценки`,о.`ID Студента`,о.`ID Предмета` 
               ,CONCAT(с.`Фамилия`, ' ', с.`Имя`, ' ', с.`Отчество`) AS 'Студент'
        FROM `Оценки` о
        INNER JOIN `Студенты` с ON с.`ID Студента` = о.`ID Студента`
        INNER JOIN `Предметы` п ON п.`ID Предмета` = о.`ID Предмета`;";

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
