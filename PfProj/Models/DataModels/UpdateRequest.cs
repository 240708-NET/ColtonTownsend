namespace PfProj.Models.DataModels;

using System.ComponentModel.DataAnnotations;
using PfProj.Entities;

public class UpdateRequest
{ 
    //public int Id { get; set; } // maybe
    public required string FilePath { get; set; }
    public required string TestingColName { get; set; }
	public required string TargetColName { get; set; }
    public int? ObservationLimit{ get; set; }
    
}