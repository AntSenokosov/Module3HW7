namespace Module3HW7.Helpers;

public class BusinessException : Exception
{
    public BusinessException(string message)
        : base(message)
    {
    }
}