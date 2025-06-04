using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace Haczykowefajtlapy.Controllers;


[ApiController]
[Route("api/pdf")]
public class PdfController : ControllerBase
{
    private readonly Data.FishingClubContext _context;

    public PdfController(Data.FishingClubContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPdf(int id)
    {
        var comp = await _context.FishingCompetitions.FindAsync(id);
        if (comp is null)
            return NotFound();

        var doc = new ApplicationDocument(comp);
        var stream = new MemoryStream();
        doc.GeneratePdf(stream);
        stream.Position = 0;

        var fileName = $"Podanie_{comp.Name.Replace(" ", "_")}.pdf";

        return File(stream, "application/pdf", fileName);
    }
}