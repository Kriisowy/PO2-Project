using Haczykowefajtlapy.Model;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Haczykowefajtlapy;

public class ApplicationDocument : IDocument
{
    private readonly FishingCompetition _comp;

    public ApplicationDocument(FishingCompetition comp)
    {
        _comp = comp;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(2, Unit.Centimetre);

            page.Header().Text("Podanie o udział w zawodach").FontSize(20).Bold().AlignCenter();

            page.Content().PaddingVertical(20).Column(col =>
            {
                col.Item().Text($"Nazwa zawodów: {_comp.Name}");
                col.Item().Text($"Data: {_comp.Date:yyyy-MM-dd}");
                col.Item().Text($"Lokalizacja: {_comp.Location}");
                col.Item().Text($"Typ zawodów: {_comp.CompetitionType}");

                col.Item().PaddingTop(20).Text("Zwracam się z prośbą o dopuszczenie do udziału w powyższych zawodach wędkarskich.");
                col.Item().PaddingTop(40).Text("...................................................\n(podpis uczestnika)").AlignCenter();
            });

            page.Footer().AlignCenter().Text(text =>
            {
                text.Span("Haczykowe Fajtlapy 2025");
            });
        });
    }
}