namespace Forpost.Common.Exceptions;

public abstract class ForpostExceptionBase(string message) : Exception(message), IErrorDescription
{
    public abstract string ErrorCode { get; }
    public virtual string ShortDescription => string.Empty;
}

public interface IErrorDescription
{
    public string ErrorCode { get; }
    public string ShortDescription { get; }
}