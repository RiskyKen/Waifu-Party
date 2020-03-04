using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using Waifu_Party.Gui;
using Waifu_Party.Level;

namespace Waifu_Party
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class WaifuParty : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AssetManager _assetManager;
        private GuiManager _guiManager;
        private LevelManager _levelManager;

        // Test crap
        private Texture2D textureAkkoDark;
        private Texture2D textureAkkoLight;
        private int imageTimer;

        public WaifuParty()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
        }

        protected void OnResize(Object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += new EventHandler<EventArgs>(OnResize);
            _assetManager = new AssetManager("assets/");
            _guiManager = new GuiManager();
            _guiManager.OpenGui(new GuiMainMenu());
            _levelManager = new LevelManager();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _assetManager.LoadContent();
            _levelManager.LoadContent(_assetManager);

            // Load test level.
            LevelInfo levelInfo = _levelManager.GetLevelInfos()[0];
            _levelManager.LoadLevel(levelInfo);

            // Test crap
            textureAkkoDark = _assetManager.LoadTexture("characters/akko_dark.jpg");
            textureAkkoLight = _assetManager.LoadTexture("characters/akko_light.jpg");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Dispose();
            _levelManager.Dispose();
            _assetManager.Dispose();

            // Test crap
            textureAkkoDark.Dispose();
            textureAkkoLight.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _guiManager.Update(gameTime);
            _levelManager.Update(gameTime);

            // Test crap
            imageTimer++;
            if (imageTimer > 49)
            {
                imageTimer = 0;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _levelManager.Draw(gameTime);

            // Vic am guessing this should be draw?
            _guiManager.Update(gameTime);


            _spriteBatch.Begin();
            if (imageTimer > 24)
            {
                _spriteBatch.Draw(textureAkkoDark, new Vector2(0, 0), Color.White);
            }
            else
            {
                _spriteBatch.Draw(textureAkkoLight, new Vector2(0, 0), Color.White);
            }
            _spriteBatch.End();

            _guiManager.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }

        public AssetManager GetAssetManager()
        {
            return this._assetManager;
        }

        public GuiManager GetGuiManager()
        {
            return this._guiManager;
        }

        public LevelManager GetLevelManager()
        {
            return this._levelManager;
        }
    }
}
