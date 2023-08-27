using H.Generators.Extensions;

namespace H.Generators;

internal static partial class Sources
{
    private static string GenerateAddOwnerCreateCall(ClassData @class, DependencyPropertyData property)
    {
        if (@class.Framework == Framework.Avalonia)
        {
            if (property.IsDirect)
            {
                return @$"
            {GenerateFromType(property)}.{property.Name}Property.AddOwner<{GenerateType(@class.FullName, false)}>(
                {GenerateAvaloniaRegisterMethodArguments(@class, property)});";
            }

            return @$"
            {GenerateFromType(property)}.{property.Name}Property.AddOwner<{GenerateType(@class.FullName, false)}>();";
        }

        return @$"
            {GenerateFromType(property)}.{property.Name}Property.AddOwner(
                ownerType: typeof({GenerateType(@class.FullName, false)}),
                {GeneratePropertyMetadata(@class, property)});
    ".RemoveBlankLinesWhereOnlyWhitespaces();
    }
}