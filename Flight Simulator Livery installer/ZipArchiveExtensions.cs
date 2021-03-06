﻿using System.IO;
using System.IO.Compression;

namespace Flight_Simulator_Livery_installer
{
    public static class ZipArchiveExtensions
    {
        public static void ExtractToDirectory(this ZipArchive archive, string destinationDirectoryName, bool overwrite)
        {
            if (!overwrite)
            {
                archive.ExtractToDirectory(destinationDirectoryName);
                return;
            }
            foreach (ZipArchiveEntry file in archive.Entries)
            {
                string completeFileName = Path.Combine(destinationDirectoryName, file.FullName);
                string directory = Path.GetDirectoryName(completeFileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    System.GC.Collect();
                }

                if (file.Name != "")
                    file.ExtractToFile(completeFileName, true);

            }
        }
    }
}
