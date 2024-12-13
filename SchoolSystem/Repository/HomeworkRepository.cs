using MySql.Data.MySqlClient;
using SchoolSystem.Infrastructure;
using SchoolSystem.Model;
using System.Data;

namespace SchoolSystem.Repository;

public class HomeworkRepository
{
    /// <summary>
    /// Добавляет новое домашнее задание в базу данных.
    /// </summary>
    /// <param name="homework">Модель домашнего задания, содержащая информацию для добавления.</param>
    /// <returns>Возвращает true, если задание успешно добавлено; иначе false.</returns>
    public bool AddHomework(HomeworkModel homework)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = @"INSERT INTO `Домашнее задание` (`ID Группы`, `ID Предмета`, `Дата`, `Домашнее задание`)
                         VALUES (@GroupId, @SubjectId, @HomeworkDate, @HomeworkBody);";

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@GroupId", homework.GroupId);
            command.Parameters.AddWithValue("@SubjectId", homework.SubjectId);
            command.Parameters.AddWithValue("@HomeworkDate", homework.HomeworkDate);
            command.Parameters.AddWithValue("@HomeworkBody", homework.HomeworkBody);

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
    /// Обновляет существующее домашнее задание в базе данных.
    /// </summary>
    /// <param name="homework">Модель домашнего задания, содержащая обновленную информацию.</param>
    /// <returns>Возвращает true, если задание успешно обновлено; иначе false.</returns>
    public bool UpdateHomework(HomeworkModel homework)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = @"UPDATE `Домашнее задание`
                         SET `ID Группы` = @GroupId,
                             `ID Предмета` = @SubjectId,
                             `Дата` = @HomeworkDate,
                             `Домашнее задание` = @HomeworkBody
                         WHERE `ID Задания` = @HomeworkId;";

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@GroupId", homework.GroupId);
            command.Parameters.AddWithValue("@SubjectId", homework.SubjectId);
            command.Parameters.AddWithValue("@HomeworkDate", homework.HomeworkDate);
            command.Parameters.AddWithValue("@HomeworkBody", homework.HomeworkBody);
            command.Parameters.AddWithValue("@HomeworkId", homework.HomeworkId);

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
    /// Удаляет домашнее задание из базы данных.
    /// </summary>
    /// <param name="homeworkId">Идентификатор задания для удаления.</param>
    /// <returns>Возвращает true, если задание успешно удалено; иначе false.</returns>
    public bool DeleteHomework(int homeworkId)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = "DELETE FROM `Домашнее задание` WHERE `ID Задания` = @HomeworkId;";
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@HomeworkId", homeworkId);

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

    public DataTable GetHomework()
    {
        string query = @"
        SELECT дз.`ID Задания`, дз.`ID Группы`,дз.`ID Предмета`,дз.`Дата`,дз.`Домашнее задание`
        ,п.`Наименование` AS Группа, пр.`Наименование` as Предмет
        FROM `Домашнее задание` дз
        INNER JOIN Группы п on п.`ID Группы` = дз.`ID Группы`
        INNER JOIN Предметы пр on пр.`ID Предмета` = дз.`ID Предмета`";

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
