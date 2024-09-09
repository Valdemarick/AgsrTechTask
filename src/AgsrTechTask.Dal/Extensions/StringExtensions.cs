using AgsrTechTask.Dal.Patient;

namespace AgsrTechTask.Dal.Extensions;

public static class StringExtensions
{
    private static readonly PatientListFilter EmptyFilter = new() { Operation = ComparisonOperation.None };
    
    public static PatientListFilter GetPatientListFilter(this string? filter)
    {
        if (string.IsNullOrEmpty(filter))
        {
            return EmptyFilter;
        }

        if (!DateTime.TryParse(filter.AsSpan(2, filter.Length - 2), out var dateTime))
        {
            return EmptyFilter;
        }
        
        return new PatientListFilter
        {
            Operation = SpecifyOperation(filter[..2]),
            DateTime = dateTime,
        };
    }

    private static ComparisonOperation SpecifyOperation(string str) => str switch
    {
        "eq" => ComparisonOperation.Equals,
        "ne" => ComparisonOperation.NotEquals,
        "lt" => ComparisonOperation.LessThan,
        "gt" => ComparisonOperation.GreaterThan,
        "ge" => ComparisonOperation.Ge,
        "le" => ComparisonOperation.Le,
        "sa" => ComparisonOperation.StartsAfter,
        "eb" => ComparisonOperation.EndsBefore,
        "ap" => ComparisonOperation.Ap,
        _ => ComparisonOperation.None,
    };
}