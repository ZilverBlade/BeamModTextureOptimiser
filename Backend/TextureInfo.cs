using System;
using System.Collections.Generic;
using System.Text;

namespace BeamModTextureOptimiser
{
    public class TextureInfo
    {
        public readonly string fullPath;
        public readonly long fileSize;

        public TextureInfo(string fullPath, long fileSize)
        {
            this.fullPath = fullPath;
            this.fileSize = fileSize;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(fullPath);
            hash.Add(fileSize);
            return hash.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null || obj.GetType() != this.GetType()) return false;
            TextureInfo that = (TextureInfo)obj;
            return that.fileSize == this.fileSize && that.fullPath == this.fullPath;
        }
    }
}
