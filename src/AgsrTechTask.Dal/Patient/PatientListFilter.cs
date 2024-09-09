namespace AgsrTechTask.Dal.Patient;

public sealed record PatientListFilter
{
    public DateTime DateTime { get; init; }

    public ComparisonOperation Operation { get; init; }
}

public enum ComparisonOperation : byte
{
    None = 0,
    
    Equals = 1,
    
    NotEquals = 2,
    
    LessThan = 3,
    
    GreaterThan = 4,
    
    Ge = 5,
    
    Le = 6,
    
    StartsAfter = 7,
    
    EndsBefore = 8,
    
    Ap = 9,
}