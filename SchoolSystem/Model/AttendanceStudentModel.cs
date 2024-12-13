namespace SchoolSystem.Model;

public class AttendanceStudentModel
{
    public int AttendanceStudentId { get; set; }
    public int StudentId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public bool IsAttendance { get; set; }
}
