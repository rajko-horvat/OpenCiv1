namespace OpenCiv1.Exceptions;

public class ApplicationExitException : Exception
{
    public ApplicationExitException() : base()
    {
    }

    public ApplicationExitException(string message) : base(message)
    {
    }

    public ApplicationExitException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
