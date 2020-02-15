using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waifu_Party.Level
{
    public static class LevelLoader
    {
        public static Level Load(string filePath)
        {
            throw new NotImplementedException();
        }

    }

    public static class LevelMetadataLoader
    {
        public static LevelInfo Load(string filePath)
        {
            LevelInfo levelMetadata = null;
            if (File.Exists(filePath))
            {

            }
            else
            {
                throw new FileNotFoundException("Failed to find the level file: " + filePath);
            }
            return levelMetadata;
        }
    }
}
