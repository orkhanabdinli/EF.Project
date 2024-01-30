namespace ConsoleApp.Task.Business.Utilities.Exceptions;

public class DoesNotExistException : Exception
{
    public DoesNotExistException(string message) : base(message)
    {

    }
}
