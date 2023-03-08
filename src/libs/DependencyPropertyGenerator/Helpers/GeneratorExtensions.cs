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

    public static ITypeSymbol? GetGenericTypeArgument(this AttributeData attributeData, int position)
    {
        attributeData = attributeData ?? throw new ArgumentNullException(nameof(attributeData));
        
        return attributeData.AttributeClass?.TypeArguments.ElementAtOrDefault(position);
    }

    public static TypedConstant GetNamedArgument(this AttributeData attributeData, string name)
    {
        attributeData = attributeData ?? throw new ArgumentNullException(nameof(attributeData));
        
        return attributeData.NamedArguments
            .FirstOrDefault(pair => pair.Key == name)
            .Value;
    }

    public static string? GetNamedArgumentExpression(this AttributeSyntax attributeSyntax, string name)
    {
        attributeSyntax = attributeSyntax ?? throw new ArgumentNullException(nameof(attributeSyntax));
        
        return attributeSyntax.ArgumentList?.Arguments
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
