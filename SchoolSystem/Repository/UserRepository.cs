using MySql.Data.MySqlClient;
using SchoolSystem.Infrastructure;
using SchoolSystem.Model;

namespace SchoolSystem.Repository;

public class UserRepository
{
    public bool LoginUser(UserModel user)
    {
        try
        {
            using MySqlConnection connection = new(Database.connectionString);
            connection.Open();

            string query = @"SELECT `ID Пользователя`, `Роль`, `Логин`
            FROM Пользователи 
            WHERE `Логин` = @Login AND `Пароль` = @Password;";

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Login", user.Login);
            command.Parameters.AddWithValue("@Password", user.Password);

            using MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                CurrentUser.Role = reader.GetString(reader.GetOrdinal("Роль"));

                return true;
            }

            return false;
        }
        catch (Exception)
        {
            MessageBox.Show("Ошибка при входе в систему.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
