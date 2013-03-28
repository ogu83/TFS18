using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BounceBall.GameObjects
{
    public abstract class LevelBase
    {
        /// <summary>
        /// Event of level complete
        /// </summary>
        public event EventHandler OnLevelCompleted;

        /// <summary>
        /// Bricks in this level
        /// </summary>
        public List<Brick> Bricks = new List<Brick>();

        protected bool _isCompleted = false;
        /// <summary>
        /// gets or sets whether the level is completed
        /// </summary>
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;

                if (_isCompleted)
                    if (OnLevelCompleted != null)
                        OnLevelCompleted(this, null);
            }
        }

        /// <summary>
        /// inits all the elements in this level
        /// </summary>
        /// <param name="brickTexture"></param>
        internal virtual void Initialize(Texture2D brickTexture)
        {
            foreach (Brick b in Bricks)
            {
                b.Initialize(brickTexture);
                b.BallCollided += new EventHandler(BallCollided);
            }
        }

        protected virtual void BallCollided(object sender, EventArgs e)
        {
            Brick myBrick = sender as Brick;
            if (myBrick != null)
                Bricks.Remove(myBrick);
        }

        /// <summary>
        /// draws all the elements in this level
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        internal virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Brick b in Bricks)
                b.Draw(spriteBatch, gameTime);
        }

        /// <summary>
        /// Updates all the elements in this level
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="gameTime"></param>
        internal virtual void Update(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            foreach (Brick b in Bricks)
                b.Update(graphics, gameTime);
        }

        /// <summary>
        /// Checks the collision with this brick and the ball
        /// </summary>
        /// <param name="ball">Ball of the current player</param>
        internal virtual void CheckCollision(List<Ball> balls)
        {
            foreach (Ball ball in balls)
                for (int i = 0; i < this.Bricks.Count; i++)
                    Bricks[i].CheckCollision(ball);
        }
    }
}
