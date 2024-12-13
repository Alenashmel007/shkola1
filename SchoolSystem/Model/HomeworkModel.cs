namespace SchoolSystem.Model;

public class HomeworkModel
{
    public int HomeworkId { get; set; }
    public string HomeworkBody { get; set; }    
    public DateTime HomeworkDate { get; set; }
    public int GroupId { get; set; }
    public int SubjectId { get; set; }
}
