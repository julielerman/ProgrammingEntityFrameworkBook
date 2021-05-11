using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Model
{
  [CustomValidation(typeof(Trip), "TripDateValidator")]
  [CustomValidation(typeof(Trip), "TripCostInDescriptionValidator")]
  public class Trip : IValidatableObject
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Identifier { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [CustomValidation(typeof(BusinessValidations), "DescriptionRules")]
    public string Description { get; set; }
    public decimal CostUSD { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }

    public int DestinationId { get; set; }
    [Required]
    public Destination Destination { get; set; }
    public List<Activity> Activities { get; set; }

    public IEnumerable<ValidationResult> Validate(
      ValidationContext validationContext)
    {
      if (StartDate.Date >= EndDate.Date)
      {
        yield return new ValidationResult(
          "Start Date must be earlier than End Date",
          new[] { "StartDate", "EndDate" });
      }

      var unwantedWords = new List<string> 
      {
        "sad", 
        "worry", 
        "freezing", 
        "cold" 
      };

      var badwords = unwantedWords
        .Where(word => Description.Contains(word));

      if (badwords.Any())
      {
        yield return new ValidationResult(
          "Description has bad words: " + string.Join(";", badwords),
          new[] { "Description" });
      }
    }

    public static ValidationResult TripDateValidator(
      Trip trip,
      ValidationContext validationContext)
    {
      if (trip.StartDate.Date >= trip.EndDate.Date)
      {
        return new ValidationResult(
          "Start Date must be earlier than End Date",
          new[] { "StartDate", "EndDate" });
      }

      return ValidationResult.Success;
    }

    public static ValidationResult TripCostInDescriptionValidator(
      Trip trip,
      ValidationContext validationContext)
    {
      if (trip.CostUSD > 0)
      {
        if (trip.Description
          .Contains(Convert.ToInt32(trip.CostUSD).ToString()))
        {
          return new ValidationResult(
            "Description cannot contain trip cost",
            new[] { "Description" });
        }
      }

      return ValidationResult.Success;
    }
  }
}