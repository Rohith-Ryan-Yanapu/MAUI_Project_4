using SQLite;
namespace Calculator.Models;

public class HistoryItem
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Expression { get; set; }
}
