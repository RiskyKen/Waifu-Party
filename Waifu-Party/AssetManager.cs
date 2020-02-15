using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Waifu_Party
{
    public class AssetManager : IDisposable
    {
        private readonly String PathAssets;
        private const String PathMod = "core/common/";
        private const String PathImages = "sprites/";

        private Texture2D missingImage;

        public AssetManager(String assetsPath)
        {
            this.PathAssets = assetsPath;
        }

        public void LoadContent()
        {
            missingImage = LoadTexture("missing.png");
        }

        public void Dispose()
        {
            missingImage.Dispose();
            // TODO: Unload assets.
        }

        public Texture2D LoadTexture(String filePath)
        {
            Texture2D texture2D = null;
            String finalPath = PathAssets + PathMod + PathImages + filePath;
            
            if (File.Exists(finalPath))
            {
                FileStream filestream = null;
                try
                {
                    filestream = new FileStream(finalPath, FileMode.Open);
                    texture2D = Texture2D.FromStream(Program.GetWaifuParty().GraphicsDevice, filestream);
                    filestream.Close();
                }
                finally
                {
                    filestream.Dispose();
                }
                if (texture2D == null)
                {
                    // Something went wrong when loading the image.
                    texture2D = missingImage;
                }
            }
            else
            {
                // The image file want not found.
                texture2D = missingImage;
            }

            return texture2D;
        }
    }
}
