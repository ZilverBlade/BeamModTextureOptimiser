using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace BeamModTextureOptimiser
{
    public class ModContext
    {
        private List<string> bakFiles = new List<string>();
        private long bakFileStorage = 0;

        private uint totalDuplicates;
        private Dictionary<TextureIdentifier, List<TextureInfo>> mappedDuplicates = new Dictionary<TextureIdentifier, List<TextureInfo>>();
        private HashSet<string> toReplaceStrings = new HashSet<string>();
        private string path = null;
        DirectoryInfo vehicleDirInfo = null;
        DirectoryInfo rootDirInfo = null;
        public ModContext()
        {

        }
        public void LoadPath(string path)
        {
            Debug.Assert(this.path == null);

            if (!Directory.Exists(path + "/vehicles"))
            {
                throw new DirectoryNotFoundException($"'{path}/vehicles' Does not exist! Please pick the **ROOT** folder of the mod!");
            }
            this.path = path;
            vehicleDirInfo = new DirectoryInfo(path + "/vehicles");
            rootDirInfo = new DirectoryInfo(path);
        }
        public void FindDuplicates()
        {
            totalDuplicates = 0;
            mappedDuplicates.Clear();
            toReplaceStrings.Clear();

            Debug.Assert(path != null && vehicleDirInfo != null, "Path cannot be null!");

            foreach (var folder in vehicleDirInfo.EnumerateDirectories())
            {
                // only check root!! anything in specialised folders is probably vehicle specific anyway
                foreach (var file in folder.EnumerateFiles("*.dds", SearchOption.TopDirectoryOnly))
                {
                    TextureIdentifier identifier = new TextureIdentifier(file.Name, file.Length);
                    TextureInfo info = new TextureInfo(file.FullName, file.Length);

                    List<TextureInfo> infoList = null;
                    if (!mappedDuplicates.TryGetValue(identifier, out infoList))
                    {
                        infoList = new List<TextureInfo>();
                        mappedDuplicates.Add(identifier, infoList);
                    }

                    infoList.Add(info);
                }
            }
            List<TextureIdentifier> toRemove = new List<TextureIdentifier>();
            foreach (var kv in mappedDuplicates)
            {
                if (kv.Value == null || kv.Value.Count < 2)
                {
                    toRemove.Add(kv.Key);
                    continue;
                }
                toReplaceStrings.Add(kv.Key.fileName);
                totalDuplicates += (uint)kv.Value.Count;
            }
            foreach (var key in toRemove)
            {
                mappedDuplicates.Remove(key);
            }
        }
        public void RemapDuplicates(out int failedMoves, out int failedDeletes, out int failedRewrites)
        {
            failedMoves = 0;
            failedDeletes = 0;
            failedRewrites = 0;
            Debug.Assert(path != null, "Path cannot be null!");

            IProgressDialog progress = Win32Factory.CreateProgressDialogue();
            progress.StartProgressDialog(IntPtr.Zero, null, ProgressDialogFlags.Normal, IntPtr.Zero);
            progress.SetTitle("Remapping files...");
            progress.SetLine(0, "Creating paths...", false, IntPtr.Zero);
            if (!Directory.Exists(path + "/vehicles/common"))
            {
                Directory.CreateDirectory(path + "/vehicles/common");
            }
            if (!Directory.Exists(path + "/vehicles/common/textures"))
            {
                Directory.CreateDirectory(path + "/vehicles/common/textures");
            }
            progress.SetLine(0, "Moving textures", false, IntPtr.Zero);
            uint currProg = 0;
            progress.SetProgress(0, totalDuplicates);
            // first move all textures
            foreach (var kv in mappedDuplicates)
            {
                Debug.Assert(kv.Value != null && kv.Value.Count >= 2);
                string handle = kv.Key.fileName;
                string dstRelPath = $"vehicles/common/textures/{handle}";
                progress.SetLine(1, $"Modifying {handle}", false, IntPtr.Zero);
                // does the texture already exist in the commons folder?
                if (!Directory.Exists($"{path}/{dstRelPath}"))
                {
                    try
                    {
                        File.Move(kv.Value[0].fullPath, $"{path}/{dstRelPath}");
                        kv.Value.RemoveAt(0);
                    }
                    catch
                    {
                        ++failedMoves;
                    }
                    progress.SetProgress(currProg++, totalDuplicates);
                } 
                else // otherwise remove it from the list!!!
                {
                   kv.Value.RemoveAll((tex) => { return tex.fullPath.EndsWith(dstRelPath); });
                }
                foreach (var texture in kv.Value)
                {
                    progress.SetLine(2, $"Erasing from {texture.fullPath.Substring(path.Length)}", false, IntPtr.Zero);
                    try
                    {
                        File.Delete(texture.fullPath);
                    }
                    catch
                    {
                        ++failedDeletes;
                    }
                    progress.SetProgress(currProg++, totalDuplicates);
                }
                if (progress.HasUserCancelled())
                {
                    failedDeletes = (int)(totalDuplicates - currProg);
                    failedMoves = (int)(totalDuplicates - currProg);
                    progress.StopProgressDialog();
                    return;
                }
            }
            uint numCars = 0;
            currProg = 0;
            foreach (var _ in vehicleDirInfo.EnumerateFiles("*.materials.json", SearchOption.AllDirectories))
            {
                ++numCars;
            }
            progress.SetLine(0, "Refactoring materials.json", false, IntPtr.Zero);
            progress.SetProgress(0, numCars);
            progress.SetLine(2, "", false, IntPtr.Zero);

            // now fix the main.materials.json
            foreach (var file in vehicleDirInfo.EnumerateFiles("*.materials.json", SearchOption.AllDirectories))
            {
                progress.SetLine(1, $"Rewriting vehicle {file.Directory.Name}", false, IntPtr.Zero);
                StreamReader reader;
                try
                {
                    reader = new StreamReader(file.FullName);
                } 
                catch
                {
                    ++failedRewrites;
                    continue;
                }
                string result = reader.ReadToEnd();
                reader.Close();
                foreach (var occurrence in toReplaceStrings) 
                {
                    result = result.Replace($"\"{occurrence}\"", $"\"/vehicles/common/textures/{occurrence}\"", StringComparison.OrdinalIgnoreCase);
                    // in case if it's using an absolute path instead
                    result = result.Replace($"\"/vehicles/{file.Directory.Name}/{occurrence}\"", $"\"/vehicles/common/textures/{occurrence}\"", StringComparison.OrdinalIgnoreCase);
                }
                try
                {
                    File.WriteAllText(file.FullName, result);
                }
                catch
                {
                    ++failedRewrites;
                    continue;
                }
                progress.SetProgress(currProg++, numCars);
                if (progress.HasUserCancelled())
                {
                    failedRewrites = (int)(numCars - currProg);
                    progress.StopProgressDialog();
                    return;
                }
            }
            progress.StopProgressDialog();
        }
        // name, duplicates, size
        public List<DuplicateInfo> GetDuplicateInfos()
        {
            List<DuplicateInfo> duplicates = new List<DuplicateInfo>();
            foreach (var kv in mappedDuplicates)
            {
                Debug.Assert(kv.Value != null && kv.Value.Count >= 2);
                DuplicateInfo info = new DuplicateInfo();
                info.name = kv.Key.fileName;
                info.size = kv.Value[0].fileSize;
                info.numDuplicates = kv.Value.Count;
                duplicates.Add(info);
            }
            return duplicates;
        }

        public uint GetNumDuplicates()
        {
            return totalDuplicates;
        }
        public int GetBakCount()
        {
            return bakFiles.Count;
        }
        public long GetBakTotalSpace()
        {
            return bakFileStorage;
        }
        public void FindBak()
        {
            Debug.Assert(rootDirInfo != null, "Root directory must not be null!");
            bakFiles.Clear();
            bakFileStorage = 0;
            foreach (var file in vehicleDirInfo.EnumerateFiles("*.bak", SearchOption.AllDirectories))
            {
                bakFiles.Add(file.FullName);
                bakFileStorage += (long)file.Length;
            }
          }
        public void DeleteBak()
        {
            Debug.Assert(rootDirInfo != null, "Root directory must not be null!");
            if (bakFiles.Count == 0) return;

            IProgressDialog progress = Win32Factory.CreateProgressDialogue();
            progress.StartProgressDialog(IntPtr.Zero, null, ProgressDialogFlags.Normal, IntPtr.Zero);
            progress.SetTitle("Remapping files...");
            progress.SetLine(1, "Deleting bak files...", false, IntPtr.Zero);
            progress.SetProgress(0, (uint)bakFiles.Count);
            uint i = 0;
            foreach (var file in bakFiles)
            {
                progress.SetLine(2, $"Deleting {file}", false, IntPtr.Zero);
                File.Delete(file);
                progress.SetProgress(i++, (uint)bakFiles.Count);
                if (progress.HasUserCancelled())
                {
                    progress.StopProgressDialog();
                    return;
                }
            }
            progress.StopProgressDialog();
        }
    }
}
