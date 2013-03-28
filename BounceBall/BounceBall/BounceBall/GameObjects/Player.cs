using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BounceBall.GameObjects
{
    public class Player
    {
        public Player() { }

        public Player(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or Sets Name of this Player
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets Score of this player
        /// </summary>
        public int Score { get; set; }

        private Ball _myBall = new Ball();
        /// <summary>
        /// gets the ball of this player
        /// </summary>
        public Ball MyBall
        {
            get { return _myBall; }
        }

        private Bar _myBar = new Bar();

        /// <summary>
        /// draws the players objects
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        internal void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _myBar.Draw(spriteBatch, gameTime);
            _myBall.Draw(spriteBatch, gameTime);
        }

        /// <summary>
        /// Inits the players objects
        /// </summary>
        /// <param name="barTexture">bar Texture</param>
        /// <param name="ballTexture">ball texture</param>
        internal void Initialize(Texture2D barTexture, Texture2D ballTexture)
        {
            _myBar.Initialize(barTexture);
            _myBall.Initialize(ballTexture);
        }

        /// <summary>
        /// updates the players objects
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="gameTime"></param>
        internal void Update(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            _myBall.Update(graphics, gameTime);
            _myBar.Update(graphics, gameTime);

            bool BallCollidedWithBar = _myBar.ObjectBounds.Intersects(_myBall.ObjectBounds);
            if (BallCollidedWithBar)
            {
                float unitAcc = 0.01F;
                _myBall.Speed.Y *= -1;
                _myBall.Speed.X = _myBar.Speed.X * unitAcc * 10;

                if (_myBall.Accerelation.X > 0)
                    _myBall.Accerelation.X = -unitAcc;
                else
                    _myBall.Accerelation.X = unitAcc;
            }
        }

        /// <summary>
        /// Changes the players bar slide speed
        /// </summary>
        /// <param name="p">slide speed (Y axis in accerelometer)</param>
        internal void ChangeBarSpeed(double p)
        {
            _myBar.Speed.X = -1 * (int)(p * 100);
        }
    }
}
