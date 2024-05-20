public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TextBook { get; set; }
    public float CreditHrs { get; set; }

    public List<Session> Sessions {get; set;}
}