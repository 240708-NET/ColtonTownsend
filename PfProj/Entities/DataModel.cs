namespace PfProj.Entities;

using System.Text.Json.Serialization;

public class DataModel
{
    public int Id { get; set; }
    // Input
    public required string FilePath { get; set; }
    // Optional Input
    public int? ObservationLimit { get; set; }
    // Intermediate Variables
    [JsonIgnore]
	public List<double>? Rm { get; set; }
    [JsonIgnore]
	public List<double>? Medv { get; set; }
    // Output
	public int? NumObservations { get; set; }
    public double? Covar {get; set; }
    public double? Cor {get; set; }
}