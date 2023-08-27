namespace H.Generators;

internal static partial class Sources
{
    private static string GenerateValidateValueCallback(DependencyPropertyData property)
    {
        if (!property.Validate)
        {
            return "null";
        }

        if (property.Framework == Framework.Maui)
        {
            return $@"static (_, value) =>
                    Is{property.Name}Valid(
                        ({GenerateType(property)})value)";
        }

        return $@"static value =>
                    Is{property.Name}Valid(
                        ({GenerateType(property)})value)";
    }

    private static string GenerateCreateDefaultValueCallbackValueCallback(DependencyPropertyData property)
    {
        if (!property.CreateDefaultValueCallback)
        {
            return "null";
        }

        if (property.Framework == Framework.Maui)
        {
            return $@"static _ => Get{property.Name}DefaultValue()";
        }

        return $@"static () => Get{property.Name}DefaultValue()";
    }
    
    private static string GenerateCoerceValueCallback(ClassData @class, DependencyPropertyData property)
    {
        if (!property.Coerce)
        {
            return "null";
        }

        var senderType = property.IsAttached
            ? GenerateBrowsableForType(property)
            : GenerateType(@class.FullName, false);

        if (property.Framework == Framework.Maui)
        {
            return property.IsAttached
                ? $@"static (sender, value) =>
                        Coerce{property.Name}(
                            ({senderType})sender,
                            ({GenerateType(property)})value)"
                : $@"static (sender, value) =>
                        (({senderType})sender).Coerce{property.Name}(
                            ({GenerateType(property)})value)";
        }

        return property.IsAttached
            ? $@"static (sender, args) =>
                        Coerce{property.Name}(
                            ({senderType})sender,
                            ({GenerateType(property)})args.Value)"
            : $@"static (sender, value) =>
                        (({senderType})sender).Coerce{property.Name}(
                            ({GenerateType(property)})value)";
    }
    
    private static string GeneratePropertyChangedCallback(ClassData @class, DependencyPropertyData property)
    {
        var (name, isChanged0, isChanged1, isChanged2, isChanged3) = CheckOnChangedMethods(@class, property);
        if (!isChanged0 &&
            !isChanged1 &&
            !isChanged2 &&
            !isChanged3)
        {
            return "null";
        }

        var senderType = property.IsAttached
            ? GenerateBrowsableForType(property)
            : GenerateType(@class.FullName, false);
        if (property.Framework == Framework.Maui)
        {
            return property.IsAttached
                ? $@"static (sender, oldValue, newValue) =>
                {{
                    {(isChanged0 ? @$"{name}();" : "")}
                    {(isChanged1 ? @$"{name}(
                        ({senderType})sender);" : "")}
                    {(isChanged2 ? @$"{name}(
                        ({senderType})sender,
                        ({GenerateType(property)})newValue);" : "")}
                    {(isChanged3 ? @$"{name}(
                        ({senderType})sender,
                        ({GenerateType(property)})oldValue,
                        ({GenerateType(property)})newValue);" : "")}
                }}"
                : $@"static (sender, oldValue, newValue) =>
                {{
                    {(isChanged0 ? @$"(({senderType})sender).{name}();" : "")}
                    {(isChanged1 ? @$"(({senderType})sender).{name}(
                        ({GenerateType(property)})newValue);" : "")}
                    {(isChanged2 ? @$"(({senderType})sender).{name}(
                        ({GenerateType(property)})oldValue,
                        ({GenerateType(property)})newValue);" : "")}
                }}";
        }

        return property.IsAttached
            ? $@"static (sender, args) =>
                    {{
                        {(isChanged0 ? @$"{name}();" : "")}
                        {(isChanged1 ? @$"{name}(
                            ({senderType})sender);" : "")}
                        {(isChanged2 ? @$"{name}(
                            ({senderType})sender,
                            ({GenerateType(property)})args.NewValue);" : "")}
                        {(isChanged3 ? @$"{name}(
                            ({senderType})sender,
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);" : "")}
                    }}"
            : $@"static (sender, args) =>
                    {{
                        {(isChanged0 ? @$"(({senderType})sender).{name}();" : "")}
                        {(isChanged1 ? @$"(({senderType})sender).{name}(
                            ({GenerateType(property)})args.NewValue);" : "")}
                        {(isChanged2 ? @$"(({senderType})sender).{name}(
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);" : "")}
                    }}";
    }

    private static bool IsMethodExists(ClassData @class, string signature)
    {
        return @class.Methods.Contains($"{@class.FullName}.{signature}");
    }
    
    private static (bool IsChanged0, bool IsChanged1, bool IsChanged2, bool IsChanged3) CheckMethods(
        string name,
        ClassData @class,
        DependencyPropertyData property)
    {
        var type = GenerateType(property)
            .Replace("global::", string.Empty)
            .Replace("?", string.Empty);
        var senderType = (property.IsAttached
                ? GenerateBrowsableForType(property)
                : GenerateType(@class.FullName, false))
            .Replace("global::", string.Empty);

        var isChanged0 =
            IsMethodExists(@class, $"{name}()");
        var isChanged1 =
            IsMethodExists(@class, $"{name}({type})") ||
            IsMethodExists(@class, $"{name}({senderType})");
        var isChanged2 =
            IsMethodExists(@class, $"{name}({type}, {type})") ||
            IsMethodExists(@class, $"{name}({senderType}, {type})");
        var isChanged3 =
            IsMethodExists(@class, $"{name}({senderType}, {type}, {type})");

        return (isChanged0, isChanged1, isChanged2, isChanged3);
    }
    
    private static (string Name, bool IsChanged0, bool IsChanged1, bool IsChanged2, bool IsChanged3)
        CheckOnChangedMethods(
            ClassData @class,
            DependencyPropertyData property)
    {
        var isCustom = !string.IsNullOrWhiteSpace(property.OnChanged);
        var name = isCustom
            ? property.OnChanged
            : $"On{property.Name}Changed";

        var (isChanged0, isChanged1, isChanged2, isChanged3) = CheckMethods(name, @class, property);
        isChanged2 |= !isCustom && !property.IsAttached && property.BindEvents.Any();
        isChanged3 |= !isCustom && property.IsAttached && property.BindEvents.Any();

        return (name, isChanged0, isChanged1, isChanged2, isChanged3);
    }

    private static string GeneratePropertyChangingCallback(ClassData @class, DependencyPropertyData property)
    {
        var (isChanging0, isChanging1, isChanging2, isChanging3) =
            CheckMethods($"On{property.Name}Changing", @class, property);
        if (!isChanging0 &&
            !isChanging1 &&
            !isChanging2 &&
            !isChanging3)
        {
            return "null";
        }

        var senderType = property.IsAttached
            ? GenerateBrowsableForType(property)
            : GenerateType(@class.FullName, false);
        if (property.Framework == Framework.Maui)
        {
            return property.IsAttached
                ? $@"static (sender, oldValue, newValue) =>
                {{
                    {(isChanging0 ? @$"On{property.Name}Changing();" : "")}
                    {(isChanging1 ? @$"On{property.Name}Changing(
                        ({senderType})sender);" : "")}
                    {(isChanging2 ? @$"On{property.Name}Changing(
                        ({senderType})sender,
                        ({GenerateType(property)})newValue);" : "")}
                    {(isChanging3 ? @$"On{property.Name}Changing(
                        ({senderType})sender,
                        ({GenerateType(property)})oldValue,
                        ({GenerateType(property)})newValue);" : "")}
                }}"
                : $@"static (sender, oldValue, newValue) =>
                {{
                    {(isChanging0 ? @$"(({senderType})sender).On{property.Name}Changing();" : "")}
                    {(isChanging1 ? @$"(({senderType})sender).On{property.Name}Changing(
                        ({GenerateType(property)})newValue);" : "")}
                    {(isChanging2 ? @$"(({senderType})sender).On{property.Name}Changing(
                        ({GenerateType(property)})oldValue,
                        ({GenerateType(property)})newValue);" : "")}
                }}";
        }

        return property.IsAttached
            ? $@"static (sender, args) =>
                    {{
                        {(isChanging0 ? @$"On{property.Name}Changing();" : "")}
                        {(isChanging1 ? @$"On{property.Name}Changing(
                            ({senderType})sender);" : "")}
                        {(isChanging2 ? @$"On{property.Name}Changing(
                            ({senderType})sender,
                            ({GenerateType(property)})args.NewValue);" : "")}
                        {(isChanging3 ? @$"On{property.Name}Changing(
                            ({senderType})sender,
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);" : "")}
                    }}"
            : $@"static (sender, args) =>
                    {{
                        {(isChanging0 ? @$"(({senderType})sender).On{property.Name}Changing();" : "")}
                        {(isChanging1 ? @$"(({senderType})sender).On{property.Name}Changing(
                            ({GenerateType(property)})args.NewValue);" : "")}
                        {(isChanging2 ? @$"(({senderType})sender).On{property.Name}Changing(
                            ({GenerateType(property)})args.OldValue,
                            ({GenerateType(property)})args.NewValue);" : "")}
                    }}";
    }
}