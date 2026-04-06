using SQLite;

namespace StudyPlanner.Models;

public class APIItem
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string APIKey { get; set; }
    
}
