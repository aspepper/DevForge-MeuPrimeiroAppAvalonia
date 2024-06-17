using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public sealed class ApplicationLifeTime<T>
{
    public T currentWindow;

    public ApplicationLifeTime(T currentWindow){
        this.currentWindow = currentWindow;
    }

    public object? CurrentWindow {
        get { 
                if (currentWindow is IClassicDesktopStyleApplicationLifetime) {
                    return ((IClassicDesktopStyleApplicationLifetime)currentWindow).MainWindow;
                }
                else if (currentWindow is ISingleViewApplicationLifetime)
                {
                    return ((ISingleViewApplicationLifetime)currentWindow).MainView;
                }

                return null;
            }
        set {
                if (value is null) return;
                if (currentWindow is IClassicDesktopStyleApplicationLifetime desktop) {
                    desktop.MainWindow = (Window)value;
                }
                else if (currentWindow is ISingleViewApplicationLifetime singleViewPlatform)
                {
                    singleViewPlatform.MainView = (UserControl)value;
                }
        }
    }

}