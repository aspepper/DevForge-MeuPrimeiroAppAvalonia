using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using MeuPrimeiroAppAvalonia.ViewModels;

namespace MeuPrimeiroAppAvalonia;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
    
    public static Type ResolveViewType(Type viewModelType)
    {
        var viewName = viewModelType.FullName.Replace("ViewModel", "View");
        var viewAssemblyName = viewModelType.Assembly.FullName;
        var viewTypeName = $"{viewName}, {viewAssemblyName}";
        return Type.GetType(viewTypeName);
    }
}