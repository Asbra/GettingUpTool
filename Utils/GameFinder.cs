using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GettingUpTool
{
    public static class GameFinder
    {
        public static bool ValidateGamePath(DirectoryInfo path)
        {
            bool isValid = false;

            if (!path.Exists)
                return false;

            // Check if folder contains _Bin and engine folders
            try
            {
                if (Directory.Exists(Path.Combine(path.FullName, "_Bin")) &&
                    Directory.Exists(Path.Combine(path.FullName, "engine")) &&
                    File.Exists(Path.Combine(path.FullName, @"_Bin\GettingUp.exe")) &&
                    File.Exists(Path.Combine(path.FullName, @"engine\allassets.pak")))
                {
                    isValid = true;
                }
            }
            catch (Exception) { }

            return isValid;
        }

        public static DirectoryInfo LocateGamePath()
        {
            // string path = string.Empty;
            DirectoryInfo path = null;

            #region Working directory check
            //
            // Check if we're in the game folder, or a subfolder of it
            //

            string[] pathsToCheck = { Environment.CurrentDirectory, Directory.GetParent(Environment.CurrentDirectory).FullName };

            foreach (string pathToCheck in pathsToCheck)
            {
                // If current directory contains GettingUp.exe we're in _Bin
                try
                {
                    if (File.Exists(Path.Combine(pathToCheck, @"GettingUp.exe")))
                    {
                        path = Directory.GetParent(pathToCheck);
                        if (ValidateGamePath(path)) return path;
                    }
                }
                catch (Exception) { }

                // If current directory contains _Bin folder we're in root
                try
                {
                    if (Directory.Exists(Path.Combine(pathToCheck, @"_Bin")))
                    {
                        path = new DirectoryInfo(pathToCheck);
                        if (ValidateGamePath(path)) return path;
                    }
                }
                catch (Exception) { }

                // If current directory contains allassets.pak we're in engine
                try
                {
                    if (File.Exists(Path.Combine(pathToCheck, @"allassets.pak")))
                    {
                        path = Directory.GetParent(pathToCheck);
                        if (ValidateGamePath(path)) return path;
                    }
                }
                catch (Exception) { }
            }
            #endregion

            #region Registry file association check
            //
            // Registry key method
            //
            RegistryKey hkCR = Registry.ClassesRoot;
            RegistryKey skSlayer = hkCR.OpenSubKey("TheCollective.Slayer\\DefaultIcon");

            if (skSlayer != null)
            {
                try
                {
                    string pathSlayer = Path.GetFullPath((string)skSlayer.GetValue(""));
                    path = new DirectoryInfo(pathSlayer);
                    if (ValidateGamePath(path)) return path;
                }
                catch (Exception) { }
            }
            #endregion

            #region Steam path parse
            //
            // Steam path method
            //
            RegistryKey hkCU = Registry.CurrentUser;
            RegistryKey skSteamPath = hkCU.OpenSubKey(@"SOFTWARE\Valve\Steam");

            if (skSteamPath != null)
            {
                try
                {
                    // Get Steam install path from registry
                    string pathSteam = Path.GetFullPath((string)skSteamPath.GetValue("SteamPath"));

                    // Parse libraryfolders.vdf
                    string pathLibFolders = Path.Combine(pathSteam, @"steamapps\libraryfolders.vdf");
                    string strLibFolders = File.ReadAllText(pathLibFolders);

                    Regex regexLibPath = new Regex(@"""path""\s+""([^""]+)""");

                    foreach (Match m in regexLibPath.Matches(strLibFolders))
                    {
                        if (m.Groups.Count < 2 || string.IsNullOrWhiteSpace(m.Groups[1].Value)) continue;

                        DirectoryInfo dirSteamLib = new DirectoryInfo(m.Groups[1].Value);
                        if (!dirSteamLib.Exists) continue;

                        // Check if this library folder contains MEGU
                        path = new DirectoryInfo(Path.Combine(pathSteam, @"steamapps\common\Marc Ecko's Getting Up 2"));
                        if (ValidateGamePath(path)) return path;
                    }
                }
                catch (Exception) { }
            }
            #endregion

            if (path == null)
                throw new DirectoryNotFoundException("Failed to find the game!");

            return path;
        }
    }
}
