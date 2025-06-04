using Haczykowefajtlapy.Model;

namespace Haczykowefajtlapy;

public static class DynamicSorter
{
    public static IEnumerable<CompetitionResult> OrderByDynamic(this IEnumerable<CompetitionResult> source, string column, bool ascending)
    {
        return column switch
        {
            "member" => ascending ? source.OrderBy(r => r.Member.LastName) : source.OrderByDescending(r => r.Member.LastName),
            "competition" => ascending ? source.OrderBy(r => r.Competition.Name) : source.OrderByDescending(r => r.Competition.Name),
            "fishType" => ascending ? source.OrderBy(r => r.FishType) : source.OrderByDescending(r => r.FishType),
            "weight" => ascending ? source.OrderBy(r => r.Weight) : source.OrderByDescending(r => r.Weight),
            "place" => ascending ? source.OrderBy(r => r.Place) : source.OrderByDescending(r => r.Place),
            _ => source
        };
    }
}