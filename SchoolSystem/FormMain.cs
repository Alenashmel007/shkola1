using SchoolSystem.Model;

namespace SchoolSystem;

public partial class FormMain : Form
{
    private Form AcriveForm { get; set; } = null;
    public FormMain()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        SetAccess(CurrentUser.Role);
    }

    private void SetAccess(string role)
    {
        switch (role.ToLower())
        {
            case "преподаватель":
                guna2Button1.Dispose();
                break;
            case "завуч":
                break;
            default:
                MessageBox.Show("Роль не определена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                break;
        }
    }

    private void guna2Button2_Click(object sender, EventArgs e)
    {
        OpenForm(new FormHomework());
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        OpenForm(new FormAttendanceStudent());
    }

    private void guna2Button8_Click(object sender, EventArgs e)
    {
        OpenForm(new FormBallStudent());
    }

    private void OpenForm(Form childForm)
    {
        AcriveForm?.Close();
        AcriveForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        panel5.Controls.Add(childForm);
        panel5.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();
    }

    private void guna2Button6_Click(object sender, EventArgs e)
    {
        FormLogin formLogin = new();
        formLogin.Show();
        Hide();
    }
}
