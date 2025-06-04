using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haczykowefajtlapy.Model;

public abstract class FishCatchBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Gatunek ryby jest wymagany.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Gatunek ryby musi mieć od 2 do 100 znaków.")]
    public string FishType { get; set; } = string.Empty;

    [Required(ErrorMessage = "Waga ryby jest wymagana.")]
    [Range(0.01, 1000.0, ErrorMessage = "Waga musi być z przedziału 0.01 – 1000 kg.")]
    public decimal Weight { get; set; }

    [Required(ErrorMessage = "Wybierz członka.")]
    public int MemberId { get; set; }
    public Member Member { get; set; } = null!;

    public abstract string DescribeCatch();
}