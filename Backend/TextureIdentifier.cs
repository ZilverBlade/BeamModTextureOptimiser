using System;
using System.Collections.Generic;
using System.Text;

namespace BeamModTextureOptimiser
{
    public class TextureIdentifier
    {
        public readonly string fileName;

        public TextureIdentifier(string fileName)
        {
            this.fileName = fileName;
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
