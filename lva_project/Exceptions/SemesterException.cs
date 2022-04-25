using System.Globalization;

namespace lva_project.Exceptions;

public class SemesterException : Exception
{
    public SemesterException() : base() {}

    public SemesterException(String message) : base(message) {}
    
    public SemesterException(string message, params object[] args) 
        : base(String.Format(CultureInfo.CurrentCulture, message, args)) {}
}
