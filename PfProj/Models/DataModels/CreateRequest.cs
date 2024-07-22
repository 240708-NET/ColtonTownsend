namespace PfProj.Models.DataModels;

using System.ComponentModel.DataAnnotations;
using PfProj.Entities;

public class CreateRequest
{
    [Required]
    public string filePath { get; set; }
}