using SchoolSystem.Common;
using SchoolSystem.Model;
using SchoolSystem.Repository;

namespace SchoolSystem;

public partial class FormHomework : Form
{
    private BindingSource BindingSource { get; set; } = new();
    private HomeworkRepository HomeworkRepository { get; set; } = new();
    private ConfirmAction ConfirmAction { get; set; } = new();

    public FormHomework()
    {
        InitializeComponent();
    }

    private void FormHomework_Load(object sender, EventArgs e)
    {
        LoadDataGrid();
        SetConfigDataGrid();
    }

    public void LoadDataGrid()
    {
        BindingSource.DataSource = HomeworkRepository.GetHomework();
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

        BindingSource.Filter = $"CONVERT([Домашнее задание], 'System.String') LIKE '%{searchText}%' OR " +
                               $"CONVERT([Группа], 'System.String') LIKE '%{searchText}%' OR " +
                               $"CONVERT([Предмет], 'System.String') LIKE '%{searchText}%'";
    }

    /// <summary>
    /// Настройки отображения столбцов data grid view
    /// </summary>
    private void SetConfigDataGrid()
    {
        using DataGridViewColumn EmployeeId = guna2DataGridView1.Columns["ID Задания"];
        EmployeeId.Visible = false;
        using DataGridViewColumn Column1 = guna2DataGridView1.Columns["ID Группы"];
        Column1.Visible = false;
        using DataGridViewColumn Column2 = guna2DataGridView1.Columns["ID Предмета"];
        Column2.Visible = false;
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
            MessageBox.Show("Для изменения выберите домашнее задание.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        HomeworkModel homework = new()
        {
            HomeworkId = (int)guna2DataGridView1.SelectedRows[0].Cells["ID Задания"].Value,
            GroupId = (int)guna2DataGridView1.SelectedRows[0].Cells["ID Группы"].Value,
            HomeworkDate = (DateTime)guna2DataGridView1.SelectedRows[0].Cells["Дата"].Value,
            HomeworkBody = guna2DataGridView1.SelectedRows[0].Cells["Домашнее задание"].Value.ToString(),
            SubjectId = (int)guna2DataGridView1.SelectedRows[0].Cells["ID Предмета"].Value
        };

        FormEditHomework formEdit = new(2, homework, this);
        formEdit.ShowDialog();
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {
        FormEditHomework formEdit = new(1, new(), this);
        formEdit.ShowDialog();
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
            MessageBox.Show("Для удаления выберите домашнее задание.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить домашнее задание?"
            , "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes)
        {
            MessageBox.Show("Действие отменено.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (HomeworkRepository.DeleteHomework((int)guna2DataGridView1.SelectedRows[0].Cells["ID Задания"].Value))
        {
            LoadDataGrid();
            MessageBox.Show("Домашнее задание успешно удалено.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
