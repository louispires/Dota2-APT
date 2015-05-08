using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using NeXt.Vdf;

namespace NeXt.APT.Steam
{
    public static class Locator
    {
        private static Lazy<string> steam_folder = new Lazy<string>(
            delegate
            {
                var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                key = key.OpenSubKey(@"SOFTWARE\Valve\Steam");
                var folder = key.GetValue("InstallPath") as string;
                return folder;
            },
            isThreadSafe: true
        );

        private static Lazy<IReadOnlyList<string>> steamapps_list = new Lazy<IReadOnlyList<string>>(
            delegate
            {
                var list = new List<string>();
                var defaultApps = Path.Combine(SteamFolder, "SteamApps");
                list.Add(defaultApps);

                var desr = VdfDeserializer.FromFile(Path.Combine(defaultApps, "libraryfolders.vdf"));
                var tbl = desr.Deserialize() as VdfTable;

                int i = 1;
                while (tbl.ContainsName(i.ToString()))
                {
                    var p = (tbl[i.ToString()] as VdfString).Content;
                    list.Add(Path.Combine(p, "SteamApps"));
                    i++;
                }

                return list.AsReadOnly();
            },
            isThreadSafe: true
        );

        private static Lazy<string> dota2_path = new Lazy<string>(
            delegate
            {
                foreach(var apps in steamapps_list.Value)
                {
                    if(File.Exists(Path.Combine(apps, "appmanifest_570.acf")))
                    {
                        var desr = VdfDeserializer.FromFile(Path.Combine(apps, "appmanifest_570.acf"));
                        var tbl = desr.Deserialize() as VdfTable;
                        var dirName = (tbl["installdir"] as VdfString).Content;
                        return Path.Combine(apps, "common", dirName);
                    }
                }


                return string.Empty;
            },
            isThreadSafe: true
        );
        
        public static string SteamFolder
        {
            get
            {
                return steam_folder.Value;
            }
        }

        public static IEnumerable<string> SteamAppsFolders
        {
            get
            {
                return steamapps_list.Value;
            }
        }

        public static string Dota2Folder
        {
            get
            {
                return dota2_path.Value;
            }
        }


    }
}
