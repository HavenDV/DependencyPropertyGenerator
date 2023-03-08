using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace H.Generators;

public static class GeneratorExtensions
{
    public static string RemoveNameof(this string value)
    {
        value = value ?? throw new ArgumentNullException(nameof(value));
        
        return value.Contains("nameof(")
            ? value
                .Substring(value.LastIndexOf('.') + 1)
                .TrimEnd(')', ' ')
            : value;
    }

    public static bool? IsSpecialType(this ITypeSymbol? symbol)
    {
        if (symbol == null)
        {
            return null;
        }

        return
            symbol.SpecialType != SpecialType.None ||
            (symbol.OriginalDefinition.SpecialType == SpecialType.System_Nullable_T &&
            symbol.BaseType != null &&
            symbol.BaseType.SpecialType != SpecialType.None);
    }

    public static ITypeSymbol? GetGenericTypeArgument(this AttributeData data, int position)
    {
        data = data ?? throw new ArgumentNullException(nameof(data));
        
        return data.AttributeClass?.TypeArguments.ElementAtOrDefault(position);
    }

    public static TypedConstant? GetProperty(this AttributeData data, string name)
    {
        data = data ?? throw new ArgumentNullException(nameof(data));
        
        return data.NamedArguments
            .FirstOrDefault(pair => pair.Key == name)
            .Value;
    }

    public static string? GetProperty(this AttributeSyntax syntax, string name)
    {
        syntax = syntax ?? throw new ArgumentNullException(nameof(syntax));
        
        return syntax.ArgumentList?.Arguments
            .FirstOrDefault(x =>
            {
                var nameEquals = x.NameEquals?.ToFullString()
                    .Trim('=', ' ', '\t', '\r', '\n');
                
                return nameEquals == name;
            })?
            .Expression
            .ToFullString();
    }
}
