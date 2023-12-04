namespace dandd.Models;

public class RaceResponse
{
    public int Count { get; set; }
    public List<Race> Results { get; set; }

}
public class Race
{
    public string Index { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
}
