using System;
using System.Runtime.InteropServices; // Needed for the Console trick
using System.Windows.Forms;
using HarmonyLib;

namespace tMPlugger.Core
{
    public class PluginLoader
    {
        // Import the Windows function to spawn a console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static void Initialize(int dummy)
        {
            // 1. Open the Debug Window
            AllocConsole();
            Console.WriteLine("========================================");
            Console.WriteLine("tMPlugger DEBUG CONSOLE ACTIVE");
            Console.WriteLine("========================================");

            try {
                Console.WriteLine("Status: Initializing Harmony...");
                var harmony = new Harmony("com.tmplugger.core");
                harmony.PatchAll();
                Console.WriteLine("Status: Harmony Patches Applied Successfully!");
            }
            catch (Exception ex) {
                // Now you will see the error here instead of a silent crash!
                Console.WriteLine("CRITICAL ERROR: " + ex.ToString());
            }
        }
    }
}