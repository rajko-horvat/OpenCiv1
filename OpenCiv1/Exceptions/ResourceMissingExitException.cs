namespace OpenCiv1.Exceptions;

public class ResourceMissingExitException : Exception
{
    public ResourceMissingExitException() : base()
    {

    }

    public ResourceMissingExitException(string? message) : base(message)
    {

    }

    public ResourceMissingExitException(string? message, Exception innerException) : base(message, innerException)
    {

    }
}