namespace PfProj.Models.DataModels;

using System.ComponentModel.DataAnnotations;
using PfProj.Entities;

public class UpdateRequest
{ 
    public required string FilePath { get; set; }
    public string? ObservationLimit{ get; set; }
    
}