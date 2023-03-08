using Microsoft.CodeAnalysis;

namespace H.Generators;

public static class ConvertExtensions
{
    public static bool ToBoolean(this TypedConstant typedConstant, bool defaultValue = false)
    {
        if (typedConstant.Value == null)
        {
            return defaultValue;
        }
        
        return (bool)typedConstant.Value!;
    }
    
    public static bool? ToNullableBoolean(this TypedConstant typedConstant)
    {
        if (typedConstant.Value == null)
        {
            return null;
        }
        
        return (bool)typedConstant.Value!;
    }

    public static T ToEnum<T>(this TypedConstant typedConstant, T defaultValue) where T : Enum
    {
        return (T)(typedConstant.Value ?? defaultValue);
    }

    public static T? ToEnum<T>(this TypedConstant typedConstant) where T : struct, Enum
    {
        if (typedConstant.Value == null)
        {
            return null;
        }
        
        return (T)typedConstant.Value;
    }
}
