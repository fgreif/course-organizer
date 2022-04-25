using System.Globalization;

namespace lva_project.Exceptions;

public class LvaException : Exception
{
    public LvaException() : base() {}

    public LvaException(String message) : base(message) {}
    
    public LvaException(string message, params object[] args) 
        : base(String.Format(CultureInfo.CurrentCulture, message, args)) {}
}