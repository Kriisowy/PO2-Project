using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haczykowefajtlapy.Model;

public class FishingLog : FishCatchBase
{
    [Required(ErrorMessage = "Data połowu jest wymagana.")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Lokalizacja jest wymagana.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Lokalizacja musi mieć od 3 do 100 znaków.")]
    public string Location { get; set; } = string.Empty;

    public override string DescribeCatch()
    {
        return $"Log: {Date:yyyy-MM-dd} – {FishType} ({Weight} kg) złowione w {Location} przez {Member.FirstName} {Member.LastName}.";
    }
}