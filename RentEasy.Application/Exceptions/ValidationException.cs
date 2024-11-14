namespace RentEasy.Application.Exceptions;

public sealed class ValidationException : Exception
{
    public IEnumerable<ValidationError> Errors { get; }
    
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }
}
