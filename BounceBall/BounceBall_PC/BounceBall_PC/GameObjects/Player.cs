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
        private Random rnd = new Random();

        public Player() { }

        public Player(string name)
        {
            Name = name;

            for (int i = 0; i < 800; i += 25)
                MyBalls.Add(new Ball(new Vector2(rnd.Next(0, 800), 450), 0.15F));
        }

        /// <summary>
        /// Gets or Sets Name of this Player
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or Sets Score of this player
        /// </summary>
        public int Score { get; set; }

        public List<Ball> MyBalls = new List<Ball>();

        private Bar _myBar = new Bar();

        /// <summary>
        /// draws the players objects
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        internal void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _myBar.Draw(spriteBatch, gameTime);
            foreach (Ball b in this.MyBalls)
                b.Draw(spriteBatch, gameTime);
        }

        /// <summary>
        /// Inits the players objects
        /// </summary>
        /// <param name="barTexture">bar Texture</param>
        /// <param name="ballTexture">ball texture</param>
        internal void Initialize(Texture2D barTexture, Texture2D ballTexture)
        {
            _myBar.Initialize(barTexture);
            foreach (Ball b in this.MyBalls)
                b.Initialize(ballTexture);
        }

        /// <summary>
        /// updates the players objects
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="gameTime"></param>
        internal void Update(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            _myBar.Update(graphics, gameTime);

            foreach (Ball b in this.MyBalls)
            {
                b.Update(graphics, gameTime);

                bool BallCollidedWithBar = _myBar.ObjectBounds.Intersects(b.ObjectBounds);
                if (BallCollidedWithBar)
                {
                    float unitAcc = 0.01F;
                    b.Speed.Y *= -1;
                    b.Speed.X = _myBar.Speed.X * unitAcc * 10;

                    if (b.Accerelation.X > 0)
                        b.Accerelation.X = -unitAcc;
                    else
                        b.Accerelation.X = unitAcc;
                }

                b.CheckCollision(this.MyBalls);
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
