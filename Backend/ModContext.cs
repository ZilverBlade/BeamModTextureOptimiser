using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BeamModTextureOptimiser
{
    public class ModContext
    {
        private Dictionary<TextureIdentifier, List<TextureInfo>> mappedDuplicates = new Dictionary<TextureIdentifier, List<TextureInfo>>();
        private string path = null;
        DirectoryInfo dirInfo = null;
        public ModContext()
        {

        }
        public void LoadPath(string path)
        {
            this.path = path;
            dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                throw new DirectoryNotFoundException($"'{path}' Does not exist! Please pick a valid mod folder");
            }
        }
        public void FindDuplicates()
        {
            Debug.Assert(path != null && dirInfo != null, "Path cannot be null!");

            foreach (var file in dirInfo.EnumerateFiles("*.dds", SearchOption.AllDirectories))
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
            List<TextureIdentifier> toRemove = new List<TextureIdentifier>();
            foreach (var kv in mappedDuplicates)
            {
                if (kv.Value == null || kv.Value.Count < 2) toRemove.Add(kv.Key);
            }
            foreach (var key in toRemove)
            {
                mappedDuplicates.Remove(key);
            }
        }
        public void RemapDuplicates()
        {
            Debug.Assert(path != null, "Path cannot be null!");

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
    }
}
