using System.IO;
using System.Reflection;

namespace MoreSkills.Utility
{
    class EmbeddedAssets
    {
        public static Stream LoadAssets(string assetPath)
        {
            Assembly objAsm = Assembly.GetExecutingAssembly();
            string[] embeddedResources = objAsm.GetManifestResourceNames();

            if (objAsm.GetManifestResourceInfo(objAsm.GetName().Name + "." + assetPath) != null)
                return objAsm.GetManifestResourceStream(objAsm.GetName().Name + "." + assetPath);
            return null;


        }
    }
}
