namespace Shared.Common.Sources.Exceptions;

/// <summary>
/// <see cref="UnauthException"/> class
/// </summary>
public class UnauthException : Exception
{
    public int StatusCode { get; set; } = 401;

    /// <summary>
    /// <see cref="UnauthException"/> ctor
    /// </summary>
    public UnauthException()
    {

    }
}
