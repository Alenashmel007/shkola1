using SchoolSystem.Infrastructure;
using SchoolSystem.Model;
using SchoolSystem.Repository;

namespace SchoolSystem;

public partial class FormEditHomework : Form
{
    public int Option { get; set; }
    private GroupStudentRepository GroupStudentRepository { get; set; } = new();
    private HomeworkRepository HomeworkRepository { get; set; } = new();
    private SubjectSchoolRepository SubjectSchoolRepository { get; set; } = new();
    private FormHomework MainForm { get; set; }
    private HomeworkModel HomeworkModel { get; set; }

    public FormEditHomework(int option, HomeworkModel homeworkModel, FormHomework formHomework)
    {
        InitializeComponent();
        Option = option;
        MainForm = formHomework;
        HomeworkModel = homeworkModel;
    }

    private void FormEditHomework_Load(object sender, EventArgs e)
    {
        LoadCombobox();

        if (Option == 1)
        {
            guna2Button1.Text = "Добавить";
            label1.Text = "Добавление";
        }
        else
        {
            guna2ComboBox2.SelectedValue = HomeworkModel.GroupId;
            guna2ComboBox1.SelectedValue = HomeworkModel.SubjectId;
            guna2TextBox1.Text = HomeworkModel.HomeworkBody;
            guna2DateTimePicker1.Value = HomeworkModel.HomeworkDate;
            guna2Button1.Text = "Сохранить";
            label1.Text = "Изменение";
        }
    }

    private void LoadCombobox()
    {
        guna2ComboBox2.DataSource = GroupStudentRepository.GetGroupStudents();
        guna2ComboBox2.DisplayMember = "Наименование";
        guna2ComboBox2.ValueMember = "ID Группы";
        guna2ComboBox2.SelectedIndex = 0;

        guna2ComboBox1.DataSource = SubjectSchoolRepository.GetSubjects();
        guna2ComboBox1.DisplayMember = "Наименование";
        guna2ComboBox1.ValueMember = "ID Предмета";
        guna2ComboBox1.SelectedIndex = 0;
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        HomeworkModel homework = new()
        {
            HomeworkId = HomeworkModel.HomeworkId,
            GroupId = (int)guna2ComboBox2.SelectedValue,
            SubjectId = (int)guna2ComboBox1.SelectedValue,
            HomeworkBody = guna2TextBox1.Text,
            HomeworkDate = (DateTime)guna2DateTimePicker1.Value,
        };

        if (Option == 1)
        {
            if (HomeworkRepository.AddHomework(homework))
            {
                MessageBox.Show("Домашнее задание успешно создано!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.LoadDataGrid();
                this.Close();
                return;
            }
        }
        else
        {
            if (HomeworkRepository.UpdateHomework(homework))
            {
                MessageBox.Show("Домашнее задание успешно изменено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.LoadDataGrid();
                this.Close();
            }
        }
    }
}
