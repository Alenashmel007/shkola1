using SchoolSystem.Model;
using SchoolSystem.Repository;

namespace SchoolSystem;

public partial class FormLogin : Form
{
    private UserRepository userRepository { get; set; } = new();

    public FormLogin()
    {
        InitializeComponent();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        guna2TextBox2.UseSystemPasswordChar = checkBox1.Checked;
    }

    private void FormLogin_Load(object sender, EventArgs e)
    {
        checkBox1.Checked = true;
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        UserModel user = new()
        {
            Login = guna2TextBox1.Text,
            Password = guna2TextBox2.Text
        };

        if (userRepository.LoginUser(user))
        {
            MessageBox.Show("Вход успешно выполнен!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormMain formMain = new();
            formMain.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Не верный логин и/или пароль", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
