﻿using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Occam.Console.Views;

namespace Occam.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddSingleton<IGameLoop, GameLoop>();
        
        services.AddServices();
        
        var serviceProvider = services.BuildServiceProvider();

        var loop = serviceProvider.GetRequiredService<IGameLoop>();
        
        while (loop.Run()) { }
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IGameConsole, GameConsole>();
        services.AddSingleton<IPlayerInputService, PlayerInputService>();
    }
}