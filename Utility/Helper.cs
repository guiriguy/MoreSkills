using System;
using UnityEngine;
using System.IO;

namespace MoreSkills.Utility
{
    static class Helper
    {
        public static Texture2D LoadPng(Stream fileStream)
        {
            Texture2D texture = null;
            if (fileStream != null)
            {
                using (var memoStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoStream);
                    texture = new Texture2D(2, 2);
                    texture.LoadImage(memoStream.ToArray()); //This will auto-resize the texture dimensions.
                }
            }
            return texture;
        }
    }
}
