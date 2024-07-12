namespace Forpost.Common.Exceptions;

public abstract class ForpostExceptionBase : Exception, IErrorDescription
{
    
    public ForpostExceptionBase(string message)
        : base(message)
    {
    }

    public abstract string ErrorCode { get; }
    public virtual string ShortDescription => string.Empty;
}

public interface IErrorDescription
{
    public string ErrorCode { get;  }
    public string ShortDescription { get; }
}