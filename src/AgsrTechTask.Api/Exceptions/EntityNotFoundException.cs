namespace AgsrTechTask.Api.Exceptions;

internal sealed class EntityNotFoundException : Exception
{
    internal EntityNotFoundException(Guid id) : base($"An entity with id = '{id}' not fouund")
    {
    }
}
