namespace SchoolSystem.Model;

public class BallStudentModel
{
    public int GradeId { get; set; } // ID Оценки
    public int SubjectId { get; set; } // ID Предмета
    public int StudentId { get; set; } // ID Студента
    public DateTime GradeDate { get; set; } // Дата оценки
    public string GradeValue { get; set; } // Оценка
}
