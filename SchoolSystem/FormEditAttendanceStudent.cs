using SchoolSystem.Infrastructure;
using SchoolSystem.Model;
using SchoolSystem.Repository;

namespace SchoolSystem;

public partial class FormEditAttendanceStudent : Form
{
    private Database DataBase { get; set; } = new();
    public int Option { get; set; }
    private FormAttendanceStudent MainForm { get; set; }
    private StudentRepository StudentRepository { get; set; } = new();
    private AttendanceStudentRepository AttendanceStudentRepository { get; set; } = new();
    private AttendanceStudentModel AttendanceStudentModel { get; set; }

    public FormEditAttendanceStudent(int option, AttendanceStudentModel attendanceStudent, FormAttendanceStudent formAttendanceStudent)
    {
        InitializeComponent();
        Option = option;
        MainForm = formAttendanceStudent;
        AttendanceStudentModel = attendanceStudent;
    }

    private void FormEditAttendanceStudent_Load(object sender, EventArgs e)
    {
        LoadCombobox();

        if (Option == 1)
        {
            guna2Button1.Text = "Добавить";
            label1.Text = "Добавление";
        }
        else
        {
            guna2ComboBox2.SelectedValue = AttendanceStudentModel.StudentId;
            guna2DateTimePicker1.Value = AttendanceStudentModel.AttendanceDate;
            guna2CheckBox1.Checked = AttendanceStudentModel.IsAttendance;
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
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        AttendanceStudentModel attendance = new()
        {
            AttendanceStudentId = AttendanceStudentModel.AttendanceStudentId,
            StudentId = (int)guna2ComboBox2.SelectedValue,
            IsAttendance = guna2CheckBox1.Checked,
            AttendanceDate = (DateTime)guna2DateTimePicker1.Value,
        };

        if (Option == 1)
        {
            if (AttendanceStudentRepository.AddAttendance(attendance))
            {
                MessageBox.Show("Посещаемость успешно выставлена!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.LoadDataGrid();
                this.Close();
                return;
            }
        }
        else
        {
            if (AttendanceStudentRepository.UpdateAttendance(attendance))
            {
                MessageBox.Show("Посещаемость успешно изменена!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.LoadDataGrid();
                this.Close();
            }
        }
    }
}
