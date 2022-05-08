using System.Reflection;
using lva_project.Exceptions;

namespace lva_project.Utils;

public interface IUtils
{
    public PropertyInfo[] GetPropertyValues(Object obj);
    public void UpdatePropertyValues(Object source, Object target);
    
}
public class Utils : IUtils
{
    /// <summary>
    /// Returns the Properties of an object.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public PropertyInfo[] GetPropertyValues(object obj)
    {
        return obj.GetType().GetProperties();
    }
    /// <summary>
    /// A Reflection-based method to update the properties of an object.
    /// While the performance itself might be lower than doing this manually,
    /// depending on the number of properties this approach safes development time.
    /// Note that while this works, it is more a "proof of concept".
    /// source = the new object; target = the object whose properties are updated.
    /// Throws an LvaException if the object types are not identical.
    /// Throws an LvaException if the number of properties are different.
    /// Various safety-checks, e.g. if the targetProperty can write.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <exception cref="LvaException"></exception>
    public void UpdatePropertyValues(Object source, Object target)
    {
        Type sourceType = source.GetType();
        Type targetType = target.GetType();
        if (sourceType != targetType)
        {
            throw new LvaException("Incompatible Types!");
        }

        PropertyInfo[] sourceProps = sourceType.GetProperties();
        PropertyInfo[] targetProps = targetType.GetProperties();

        if (sourceProps.Length != targetProps.Length)
        {
            throw new LvaException("Property length of source and target Objects do not match!");
        }
        
        foreach (var sourceProp in sourceProps)
        {
            PropertyInfo? targetProp = targetType.GetProperty(sourceProp.Name);
            if (sourceProp.GetValue(source) != sourceProp.GetValue(target) 
                && sourceProp.CanRead 
                && sourceProp.GetGetMethod(true) != null
                && targetProp != null 
                && targetProp.CanWrite
                && targetProp.GetSetMethod(true) != null)
            {
                targetProp.SetValue(target, sourceProp.GetValue(source));
            }
        }
    }
}