namespace dandd.Models;

public class RaceResponse
{
    public int Count { get; }
    public List<Race> Results { get; }

}
public class Race
{
    public string Index { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
}
