using SchoolSystem.Common;
using SchoolSystem.Model;
using SchoolSystem.Repository;

namespace SchoolSystem;

public partial class FormAttendanceStudent : Form
{
    private BindingSource BindingSource { get; set; } = new();
    private AttendanceStudentRepository AttendanceStudentRepository { get; set; } = new();
    private ConfirmAction ConfirmAction { get; set; } = new();

    public FormAttendanceStudent()
    {
        InitializeComponent();
    }

    private void FormAttendanceStudent_Load(object sender, EventArgs e)
    {
        LoadDataGrid();
        SetConfigDataGrid();
    }

    public void LoadDataGrid()
    {
        BindingSource.DataSource = AttendanceStudentRepository.GetAttendanceStudent();
        guna2DataGridView1.DataSource = BindingSource;
    }

    /// <summary>
    /// Настройки отображения столбцов data grid view
    /// </summary>
    private void SetConfigDataGrid()
    {
        using DataGridViewColumn EmployeeId = guna2DataGridView1.Columns["ID Посещаемости"];
        EmployeeId.Visible = false;
        using DataGridViewColumn Column1 = guna2DataGridView1.Columns["ID Студента"];
        Column1.Visible = false;
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
        if (BindingSource.Count == 0)
        {
            MessageBox.Show("Нет данных для редактирования.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (guna2DataGridView1.SelectedRows.Count < 0)
        {
            MessageBox.Show("Для изменения выберите посещение студента.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        AttendanceStudentModel attendance = new()
        {
            AttendanceStudentId = (int)guna2DataGridView1.SelectedRows[0].Cells["ID Посещаемости"].Value,
            AttendanceDate = (DateTime)guna2DataGridView1.SelectedRows[0].Cells["Дата"].Value,
            IsAttendance = (bool)guna2DataGridView1.SelectedRows[0].Cells["Посещение"].Value,
            StudentId = (int)guna2DataGridView1.SelectedRows[0].Cells["ID Студента"].Value,
        };

        FormEditAttendanceStudent formEditTrainer = new(2, attendance, this);
        formEditTrainer.ShowDialog();
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        if (BindingSource.Count == 0)
        {
            MessageBox.Show("Нет данных для удаления.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (guna2DataGridView1.SelectedRows.Count < 0)
        {
            MessageBox.Show("Для удаления выберите посещение.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить посещение студента?"
            , "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes)
        {
            MessageBox.Show("Действие отменено.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (AttendanceStudentRepository.DeleteAttendance((int)guna2DataGridView1.SelectedRows[0].Cells["ID Посещаемости"].Value))
        {
            LoadDataGrid();
            MessageBox.Show("Посещение успешно удалено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {
        FormEditAttendanceStudent formEditTrainer = new(1, new(), this);
        formEditTrainer.ShowDialog();
    }

    private void guna2TextBox1_TextChanged(object sender, EventArgs e)
    {
        string searchText = guna2TextBox1.Text.ToLower();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            BindingSource.RemoveFilter();
            return;
        }

        BindingSource.Filter = $"CONVERT([Группа], 'System.String') LIKE '%{searchText}%' OR " +
                               $"CONVERT([Дата], 'System.String') LIKE '%{searchText}%' OR " +
                               $"CONVERT([Студент], 'System.String') LIKE '%{searchText}%'";
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
        DGVPrinter dGVPrinter = new();
        dGVPrinter.CreateReport("Выгрузка посещаемости студентов", guna2DataGridView1);
    }
}
