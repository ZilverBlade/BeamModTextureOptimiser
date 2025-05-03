using System;
using System.Collections.Generic;
using System.Text;

namespace BeamModTextureOptimiser
{
    public class TextureIdentifier
    {
        public readonly string fileName;
        public readonly long fileSize;

        public TextureIdentifier(string fileName, long fileSize)
        {
            this.fileName = fileName;
            this.fileSize = fileSize;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(fileName);
            return hash.ToHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (obj == null || obj.GetType() != this.GetType()) return false;
            TextureIdentifier that = (TextureIdentifier)obj;
            return that.fileName == this.fileName;
        }
    }
}
