using System.ComponentModel.DataAnnotations;

namespace Haczykowefajtlapy.Model;

public class CompetitionResult : FishCatchBase
{

    [Required(ErrorMessage = "Wybierz zawody.")]
    public int CompetitionId { get; set; }
    public FishingCompetition Competition { get; set; } = null!;

    [Range(1, 1000, ErrorMessage = "Miejsce musi być większe niż 0.")]
    public int Place { get; set; }

    public override string DescribeCatch()
    {
        return $"Wynik: {Member.FirstName} {Member.LastName} – {FishType} ({Weight} kg), miejsce {Place} w zawodach '{Competition.Name}' ({Competition.Date:yyyy-MM-dd}).";
    }
}