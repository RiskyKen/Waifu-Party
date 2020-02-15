using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Waifu_Party.Level
{
    public class LevelManager : IDisposable
    {
        private const String _levelsFolder = "assets/core/common/levels/";
        private LevelInfo[] _levelInfos= new LevelInfo[0];
        private Level _currentLevel = null;

        public LevelManager()
        {

        }

        public void LoadContent(AssetManager assetManager)
        {
            LoadLevelsMetadata(_levelsFolder);
        }

        public void LoadLevel(LevelInfo levelInfo)
        {
            UnloadLevel();
            _currentLevel = LevelLoader.Load(levelInfo.GetFilename() + ".level");
        }

        public void UnloadLevel()
        {
            if (_currentLevel != null)
            {
                _currentLevel.Dispose();
            }
            _currentLevel = null;
        }

        private void LoadLevelsMetadata(String folderPath)
        {
            String[] infoFiles = Directory.GetFiles(folderPath, "*.info");
            List<LevelInfo> levelInfoList = new List<LevelInfo>();
            foreach(String infoFile in infoFiles)
            {
                LevelInfo levelInfo = LevelMetadataLoader.Load(infoFile);
                if (levelInfo != null)
                {
                    levelInfoList.Add(levelInfo);
                }
            }
            _levelInfos = levelInfoList.ToArray();
        }

        public LevelInfo[] GetLevelInfos()
        {
            return _levelInfos;
        }
        
        public void Dispose()
        {
            if (_currentLevel != null)
            {
                _currentLevel.Dispose();
            }
        }

        public void Update(GameTime gameTime)
        {
            if (_currentLevel != null)
            {
                _currentLevel.Update();
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (_currentLevel != null)
            {
                _currentLevel.Draw();
            }
        }
    }

    public class LevelInfo
    {
        private string _filename;
        private int _maxPlayer;

        public LevelInfo()
        {

        }

        public string GetFilename()
        {
            return _filename;
        }

        public int GetMaxPlayers()
        {
            return _maxPlayer;
        }
    }
}
