using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Reloaded.Injector;

namespace tMPlugger.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== tMPlugger Launcher [Console Force Mode] ===");

            // 1. Setup Paths
            string terrariaDir = @"[your terraria.exe path]";
            string terrariaPath = Path.Combine(terrariaDir, "Terraria.exe");
            
            // Build path to your compiled DLL
            string sourceDllDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "tMPlugger.Core", "bin", "Debug", "net8.0-windows"));
            string sourceDllPath = Path.Combine(sourceDllDir, "tMPlugger.Core.dll");
            
            // Destination inside Terraria folder (Better for stability)
            string targetDllPath = Path.Combine(terrariaDir, "tMPlugger.Core.dll");

            // 2. Deployment: Move DLLs if they are missing or old
            try {
                Console.WriteLine("Deploying plugins to game folder...");
                if (File.Exists(sourceDllPath)) {
                    // Copy Core DLL
                    File.Copy(sourceDllPath, targetDllPath, true);
                    
                    // Copy Harmony and API if they exist in the source folder
                    foreach (var file in Directory.GetFiles(sourceDllDir, "*.dll")) {
                        string destFile = Path.Combine(terrariaDir, Path.GetFileName(file));
                        File.Copy(file, destFile, true);
                    }
                } else {
                    Console.WriteLine("BUILD ERROR: Could not find your compiled DLL. Did you build in VS Code?");
                    return;
                }
            } catch (Exception ex) {
                Console.WriteLine($"Deployment Warning: {ex.Message}");
            }

            // 3. Launch Terraria
            Console.WriteLine("Launching Terraria...");
            Process terrariaProcess = Process.Start(new ProcessStartInfo(terrariaPath) {
                WorkingDirectory = terrariaDir
            })!;

            // 4. Wait for Menu (Increased to ensure UI is ready)
            Console.WriteLine("Waiting 15 seconds for Main Menu...");
            Thread.Sleep(30000);

            // 5. Inject & Call
            try {
                using var injector = new Injector(terrariaProcess);
                
                // Inject from the local game folder
                injector.Inject(targetDllPath);
                
                Console.WriteLine("Attaching Debug Console...");
                // This calls our method that spawns a console inside Terraria
                injector.CallFunction<int>(targetDllPath, "Initialize", 0);

                Console.WriteLine("SUCCESS: Check the new window that appeared!");
            }
            catch (Exception ex) {
                Console.WriteLine($"FATAL ERROR during injection: {ex.Message}");
            }

            Console.WriteLine("Press any key to close Launcher.");
            Console.ReadKey();
        }
    }

}
