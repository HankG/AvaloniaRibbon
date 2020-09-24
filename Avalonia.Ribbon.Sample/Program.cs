﻿using Avalonia;
using Avalonia.Logging;
using Avalonia.Platform;

namespace Avalonia.Ribbon.Samples
{
    class Program
    {
        static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                           .UsePlatformDetect()
                           
                           .LogToDebug(LogEventLevel.Warning);
        }

        // The entry point. Things aren't ready yet, so at this point
        // you shouldn't use any Avalonia types or anything that expects
        // a SynchronizationContext to be ready
        static void Main(string[] args)
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
    }
}
