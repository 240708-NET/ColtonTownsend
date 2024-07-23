namespace PfProj.Models.DataModels;

using System.ComponentModel.DataAnnotations;
using PfProj.Entities;

public class CreateRequest
{
    /* Update -> Create
    public CreateRequest(string filePath, string? observationLimit)
    {
        FilePath = filePath;
        if (observationLimit != null)
            ObservationLimit = observationLimit;
    } */
    public required string FilePath { get; set; }
    public string? ObservationLimit{ get; set; }
}