using SchoolSystem.Common;
using SchoolSystem.Model;
using SchoolSystem.Repository;

namespace SchoolSystem;

public partial class FormBallStudent : Form
{
    private BindingSource BindingSource { get; set; } = new();
    private BallRepository BallRepository { get; set; } = new();
    private ConfirmAction ConfirmAction { get; set; } = new();
    private ExportExcel exportExcel { get; set; } = new();

    public FormBallStudent()
    {
        InitializeComponent();
    }

    private void FormTrainer_Load(object sender, EventArgs e)
    {
        LoadDataGrid();
        SetConfigDataGrid();
    }


    public void LoadDataGrid()
    {
        BindingSource.DataSource = BallRepository.GetGrades();
        guna2DataGridView1.DataSource = BindingSource;
    }

    private void guna2TextBox1_TextChanged(object sender, EventArgs e)
    {
        string searchText = guna2TextBox1.Text.ToLower();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            BindingSource.RemoveFilter();
            return;
        }

        BindingSource.Filter = $"CONVERT([Оценка], 'System.String') LIKE '%{searchText}%' OR " +
                               $"CONVERT([Предмет], 'System.String') LIKE '%{searchText}%' OR " +
                               $"CONVERT([Дата оценки], 'System.String') LIKE '%{searchText}%' OR " +
                               $"CONVERT([Студент], 'System.String') LIKE '%{searchText}%'";
    }

    /// <summary>
    /// Настройки отображения столбцов data grid view
    /// </summary>
    private void SetConfigDataGrid()
    {
        using DataGridViewColumn EmployeeId = guna2DataGridView1.Columns["ID Оценки"];
        EmployeeId.Visible = false;
        using DataGridViewColumn Column1 = guna2DataGridView1.Columns["ID Предмета"];
        Column1.Visible = false;
        using DataGridViewColumn Column2 = guna2DataGridView1.Columns["ID Студента"];
        Column2.Visible = false;
    }
    private void pictureBox3_Click_1(object sender, EventArgs e)
    {
        FormEditBall formEditTrainer = new(1, new(), this);
        formEditTrainer.ShowDialog();
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
            MessageBox.Show("Для изменения выберите оценку студента.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        BallStudentModel ball = new()
        {
            GradeId = (int)guna2DataGridView1.SelectedRows[0].Cells["ID Оценки"].Value,
            GradeDate = (DateTime)guna2DataGridView1.SelectedRows[0].Cells["Дата оценки"].Value,
            GradeValue = guna2DataGridView1.SelectedRows[0].Cells["Оценка"].Value.ToString(),
            StudentId = (int)guna2DataGridView1.SelectedRows[0].Cells["ID Студента"].Value,
            SubjectId = (int)guna2DataGridView1.SelectedRows[0].Cells["ID Предмета"].Value
        };

        FormEditBall formEditTrainer = new(2, ball, this);
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
            MessageBox.Show("Для удаления выберите оценку студента.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить оценку?"
            , "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes)
        {
            MessageBox.Show("Действие отменено.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (BallRepository.DeleteGrade((int)guna2DataGridView1.SelectedRows[0].Cells["ID Оценки"].Value))
        {
            LoadDataGrid();
            MessageBox.Show("Оценка успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
        exportExcel.Export(guna2DataGridView1);
    }
}
