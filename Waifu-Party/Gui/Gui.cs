
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Waifu_Party.Gui
{
    public class GuiManager
    {
        private Gui _currentGui;

        public GuiManager()
        {
        }

        public void OpenGui(Gui gui)
        {
            _currentGui = gui;
            _currentGui.Initialize();
        }

        public void Update(GameTime gameTime)
        {
            if (_currentGui != null)
            {
                _currentGui.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_currentGui != null)
            {
                _currentGui.Draw(gameTime, spriteBatch);
            }
        }
    }

    public abstract class GuiControl
    {
        public int Width;
        public int Height;
        public Vector2 Position;

        public GuiControl(int width, int height, Vector2 position)
        {
            Width = width;
            Height = height;
            Position = position;
        }

        public void Initialize() { }
        public void Update(GameTime gameTime) { }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {}
    }

    public abstract class Gui
    {
        protected List<GuiControl> _controls = new List<GuiControl>();

        public void Initialize()
        {
            foreach (var control in _controls)
                control.Initialize();
        }

        public void Update(GameTime gameTime)
        {
            foreach (var control in _controls)
                control.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var control in _controls)
                control.Draw(gameTime, spriteBatch);
        }
    }
}
