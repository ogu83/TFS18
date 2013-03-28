using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceBall.GameObjects
{
    public class Ball : SpriteObject
    {
        public event EventHandler BallLost;

        public Ball()
        {
            base.Position = new Vector2(0, 450);
            base.Scale = 0.25F;
        }

        internal override void Update(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            base.Speed += base.Accerelation;
            base.Position += base.Speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10;

            int MaxX = graphics.GraphicsDevice.Viewport.Width - this.ScaledWidth;
            int MinX = 0;
            int MaxY = graphics.GraphicsDevice.Viewport.Height - this.ScaledHeight;
            int MinY = 0;

            // Check for bounce.
            if (base.Position.X > MaxX)
            {
                base.SwapSpeedX();
                base.Position.X = MaxX;
            }
            else if (base.Position.X < MinX)
            {
                base.SwapSpeedX();
                base.Position.X = MinX;
            }

            if (base.Position.Y > MaxY)
            {
                base.SwapSpeedY();
                base.Position.Y = MaxY;
                //if (BallLost != null)
                //    BallLost(this, null);
            }
            else if (base.Position.Y < MinY)
            {
                base.SwapSpeedY();
                base.Position.Y = MinY;
            }

            base.Update(graphics, gameTime);
        }
    }
}
