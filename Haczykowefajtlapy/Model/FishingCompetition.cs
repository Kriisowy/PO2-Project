using System.ComponentModel.DataAnnotations;

namespace Haczykowefajtlapy.Model;
using System.ComponentModel.DataAnnotations;

public class FishingCompetition
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nazwa zawodów jest wymagana.")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "Nazwa musi mieć od 5 do 150 znaków.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Data zawodów jest wymagana.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Lokalizacja jest wymagana.")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Lokalizacja musi mieć od 3 do 200 znaków.")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Typ zawodów jest wymagany.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Typ zawodów musi mieć od 3 do 50 znaków.")]
    public string CompetitionType { get; set; } = string.Empty;

    public ICollection<CompetitionResult> Results { get; set; } = new List<CompetitionResult>();
}