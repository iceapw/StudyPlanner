using SQLite;

namespace StudyPlanner.Models;

public class Key
{
    [PrimaryKey, AutoIncrement]   
    public int Id {get; set;}

    public string APIKey {get; set;}
    
     
}