using System;
using System.Reflection;

namespace defarge
{


	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
	public class LabelAttribute : Attribute
	{
	    public string Label { get; }

	    public LabelAttribute(string label)
	    {
	        Label = label;
	    }

	    public static string GetClassLabel<T>()
	    {
	        var LabelAttribute = typeof(T).GetCustomAttribute<LabelAttribute>();
	        return LabelAttribute?.Label ?? $"No Label found for class '{typeof(T).Name}'";
	    }

	    public static string GetPropertyLabel<T>(string propertyName)
	    {
	        var property = typeof(T).GetProperty(propertyName);
	        if (property != null)
	        {
	            var LabelAttribute = property.GetCustomAttribute<LabelAttribute>();
	            return LabelAttribute?.Label ?? $"No Label found for '{propertyName}'";
	        }
	        return $"Property '{propertyName}' not found";
	    }
	}
}
