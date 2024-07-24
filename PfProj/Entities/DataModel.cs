namespace PfProj.Entities;

using System.Text.Json.Serialization;

public class DataModel
{
    public int Id { get; set; }
    // Required Input
    public required string FilePath { get; set; }
    public required string TestingColName { get; set; }
	public required string TargetColName { get; set; }
    // Optional Input
    public int? ObservationLimit { get; set; }
    // Output
	public int? NumObservations { get; set; }
    public double? Covar {get; set; }
    public double? Cor {get; set; }
}