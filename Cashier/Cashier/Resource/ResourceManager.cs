using System;
using System.IO;
using System.Drawing;
using System.Reflection;

namespace Resource
{
    /// <summary>
    /// Summary description for ResourceManager.
    /// </summary>
    public class ResourceManager
    {
        private const string _sResPath = "Resource.";
        public static Image GetImage(string resId)
        {
            Stream stream = ResourceManager.GetResource(resId);
            return stream == null ? null : Image.FromStream(stream);
        }

        public static Bitmap GetBitmap(string resId)
        {
            Stream stream = ResourceManager.GetResource(resId);
            return stream == null ? null : new Bitmap(stream);
        }

        public static TextReader GetTextResource(string resId)
        {
            Stream stream = ResourceManager.GetResource(resId);
            return stream == null ? null : new StreamReader(stream);
        }

        public static Stream GetResource(string resId)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            try
            {
                return asm.GetManifestResourceStream(String.Format("{0}{1}", ResourceManager._sResPath, resId));
            }
            catch
            {
                return null;
            }
        }
    }
}
