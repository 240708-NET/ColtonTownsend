namespace PfProj.Models.DataModels;

using System.ComponentModel.DataAnnotations;
using PfProj.Entities;

public class UpdateRequest
{ 
    [Required]
    public string filePath { get; set; }
}