using System.ComponentModel.DataAnnotations.Schema;

namespace Haczykowefajtlapy.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class Member
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Imię jest wymagane.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Imię musi mieć od 2 do 100 znaków.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nazwisko jest wymagane.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Nazwisko musi mieć od 2 do 100 znaków.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Data urodzenia jest wymagana.")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Telefon jest wymagany.")]
    [Phone(ErrorMessage = "Nieprawidłowy numer telefonu.")]
    [StringLength(20, MinimumLength = 7, ErrorMessage = "Telefon musi mieć od 7 do 20 znaków.")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email jest wymagany.")]
    [EmailAddress(ErrorMessage = "Nieprawidłowy adres email.")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "Email musi mieć od 5 do 200 znaków.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Data dołączenia jest wymagana.")]
    [DataType(DataType.Date)]
    public DateTime JoinDate { get; set; }

    public bool IsActive { get; set; }

    [DataType(DataType.Date)]
    public DateTime? LicenseValidUntil { get; set; }

    public bool MembershipFeePaid { get; set; }

    public ICollection<CompetitionResult> CompetitionResults { get; set; } = new List<CompetitionResult>();
    public ICollection<FishingLog> FishingLogs { get; set; } = new List<FishingLog>();
}