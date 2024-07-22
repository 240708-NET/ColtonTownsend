namespace PfProj.Entities;

using System.Text.Json.Serialization;

public class DataModel
{
    public string filePath;

    [JsonIgnore]
	public string rm_in { get; set; }
    [JsonIgnore]
     public string medv_in { get; set; }
     [JsonIgnore]
	public List<double> rm { get; set; }
    [JsonIgnore]
	public List<double> medv { get; set; }

    [JsonIgnore]
	public int numObservations { get; set; }
}