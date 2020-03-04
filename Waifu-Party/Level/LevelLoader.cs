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
            Level level = null;
            if (File.Exists(filePath))
            {
                level = new Level(filePath);
            }
            return level;
        }

    }

    public static class LevelMetadataLoader
    {
        public static LevelInfo Load(string filePath)
        {
            LevelInfo levelMetadata = null;
            if (File.Exists(filePath))
            {
                levelMetadata = new LevelInfo(filePath);
            }
            else
            {
                throw new FileNotFoundException("Failed to find the level file: " + filePath);
            }
            return levelMetadata;
        }
    }
}
