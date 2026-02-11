# tMPlugger
A lightweight, standalone C# modding framework for Terraria 1.4.5. Built with .NET 8 and Harmony for high-performance, non-invasive game patching.
tMPlugger


---

# tMPlugger

tMPlugger is a lightweight, standalone modding framework for Terraria 1.4.5. It provides Quality of Life features and small runtime patches while the broader modding ecosystem catches up to the “Bigger and Boulder” update.

This is not a full modding platform. It is fast, minimal, and intentionally raw.

---

# The Situation

THIS PROJECT WAS MADE IN A WEEK.
DO NOT COMPLAIN THAT IT IS UNDER-DEVELOPED.

This is a solo project built so I could play Terraria 1.4.5 with my own QoL mods without waiting for tModLoader to update. It works, it is fast, and it is unfinished. Use it with that understanding.

# Also: do not question Greg.

---

# tModLoader Disclaimer

This project is NOT a replacement for tModLoader.

tModLoader is an exceptional project, and mods like Calamity are the reason Terraria modding exists at the scale it does today. tMPlugger exists only as a temporary solution for QoL tweaks and small patches until tModLoader fully supports Terraria 1.4.5.

---

# Feature Comparison

| Feature                | tMPlugger                     | tModLoader        |
| ---------------------- | ----------------------------- | ----------------- |
| Terraria 1.4.5 Support | Yes (Day 1)                   | Pending           |
| Installation           | Standalone Injector           | Steam Integrated  |
| Complexity             | Lightweight / Raw             | Full Game Rewrite |
| Purpose                | Temporary QoL / Small Patches | Full Content Mods |

---

# Technical Resources

| Resource          | Purpose                             |
| ----------------- | ----------------------------------- |
| Lib.Harmony       | Runtime C# method patching          |
| Reloaded.Injector | DLL injection into the game process |
| .NET 8.0 SDK      | Runtime environment                 |

---

# Setup and Installation

Before building, you must manually set the path to your local Terraria executable in the Program.cs.

Build the project using .NET 8.0 and run the launcher to inject the runtime into Terraria.

---

# Project Components

Launcher
Responsible for injecting the runtime into the Terraria process.

Core
Contains the logic that executes inside the game.

API
Defines shared interfaces for plugins.

---

# Intended Use

Appropriate for small QoL mods, experimental patches, and temporary 1.4.5 modding.

Not intended for large-scale content mods or long-term use as a tModLoader replacement.

---

# License

MIT License.

Use it however you want. Do not blame me if something happens to your save file.

---

