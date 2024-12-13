using SchoolSystem.Infrastructure;
using SchoolSystem.Model;
using SchoolSystem.Repository;

namespace SchoolSystem;

public partial class FormEditBall : Form
{
    private Database DataBase { get; set; } = new();
    public int Option { get; set; }
    private BallRepository BallRepository { get; set; } = new();
    public BallStudentModel BallStudentModel { get; set; } = new();
    private FormBallStudent MainForm { get; set; }
    private StudentRepository StudentRepository { get; set; } = new();
    private SubjectSchoolRepository SubjectSchoolRepository { get; set; } = new();

    public FormEditBall(int option, BallStudentModel studentModel, FormBallStudent mainForm)
    {
        InitializeComponent();
        Option = option;
        BallStudentModel = studentModel;
        MainForm = mainForm;
    }

    private void FormEditTrainer_Load(object sender, EventArgs e)
    {
        LoadCombobox();

        if (Option == 1)
        {
            guna2Button1.Text = "Добавить";
            label1.Text = "Добавление";
        }
        else
        {
            guna2ComboBox2.SelectedValue = BallStudentModel.StudentId;
            guna2ComboBox1.SelectedValue = BallStudentModel.SubjectId;
            guna2TextBox1.Text = BallStudentModel.GradeValue;
            guna2DateTimePicker1.Value = BallStudentModel.GradeDate;
            guna2Button1.Text = "Сохранить";
            label1.Text = "Изменение";
        }
    }

    private void LoadCombobox()
    {
        guna2ComboBox2.DataSource = StudentRepository.GetStudents();
        guna2ComboBox2.DisplayMember = "Студент ФИО";
        guna2ComboBox2.ValueMember = "ID Студента";
        guna2ComboBox2.SelectedIndex = 0;

        guna2ComboBox1.DataSource = SubjectSchoolRepository.GetSubjects();
        guna2ComboBox1.DisplayMember = "Наименование";
        guna2ComboBox1.ValueMember = "ID Предмета";
        guna2ComboBox1.SelectedIndex = 0;
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        BallStudentModel ball = new()
        {
            GradeId = BallStudentModel.GradeId,
            StudentId = (int)guna2ComboBox2.SelectedValue,
            SubjectId = (int)guna2ComboBox1.SelectedValue,
            GradeValue = guna2TextBox1.Text,
            GradeDate = (DateTime)guna2DateTimePicker1.Value,
        };

        if (Option == 1)
        {
            if (BallRepository.AddGrade(ball))
            {
                MessageBox.Show("Оценка успешно выставлена!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.LoadDataGrid();
                this.Close();
                return;
            }
        }
        else
        {
            if (BallRepository.UpdateGrade(ball))
            {
                MessageBox.Show("Оценка успешно изменена!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.LoadDataGrid();
                this.Close();
            }
        }
    }
}
