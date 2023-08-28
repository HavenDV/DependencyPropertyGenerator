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
            {property.FromType}.{property.Name}Property.AddOwner<{@class.Type}>(
                {GenerateAvaloniaRegisterMethodArguments(@class, property)});";
            }

            return @$"
            {property.FromType}.{property.Name}Property.AddOwner<{@class.Type}>();";
        }

        return @$"
            {property.FromType}.{property.Name}Property.AddOwner(
                ownerType: typeof({@class.Type}),
                {GeneratePropertyMetadata(@class, property)});
    ".RemoveBlankLinesWhereOnlyWhitespaces();
    }
}