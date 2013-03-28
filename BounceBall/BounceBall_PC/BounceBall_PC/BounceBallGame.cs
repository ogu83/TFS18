using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using BounceBall.GameObjects;

namespace BounceBall_PC
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BounceBallGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Player myPlayer = new Player("Player1");
        private GameBackground myGameBackground = new GameBackground();

        private bool OnMenu = false;
        private LevelBase myLevel = new Level1();

        public BounceBallGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            this.Window.Title = "Bounce Ball";
            this.IsMouseVisible = true;
            this.Window.AllowUserResizing = false;
            //graphics.ToggleFullScreen();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //myGameBackground.Initialize(Content.Load<Texture2D>("Background"));
            myGameBackground.Initialize(Content.Load<Texture2D>("GridBlack"));
            myPlayer.Initialize(Content.Load<Texture2D>("RedBar"), Content.Load<Texture2D>("RedBall"));
            myLevel.Initialize(Content.Load<Texture2D>("YellowBrick"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            double acc = 0.05;
            // Input the game
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                myPlayer.ChangeBarSpeed(acc);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                myPlayer.ChangeBarSpeed(-acc);

            // TODO: Add your update logic here
            if (!OnMenu)
            {
                myPlayer.Update(graphics, gameTime);
                myLevel.Update(graphics, gameTime);
                myLevel.CheckCollision(myPlayer.MyBalls);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(new Color(20, 20, 40));
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            // Draw the sprite.            
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            myGameBackground.Draw(spriteBatch, gameTime);

            if (!OnMenu)
            {
                myPlayer.Draw(spriteBatch, gameTime);
                myLevel.Draw(spriteBatch, gameTime);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
