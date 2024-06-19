using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.CodeAnalysis.CSharp.Syntax;

public sealed class AppAvaloniaLifeTime<T>
{
    public T currentWindow;

    public AppAvaloniaLifeTime(T currentWindow){
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