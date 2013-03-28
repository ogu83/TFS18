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

        public Ball(Vector2 position)
        {
            base.Position = position;
            base.Scale = 0.25F;
        }

        public Ball(Vector2 position, float scale)
        {
            base.Position = position;
            base.Scale = scale;
        }

        internal void CheckCollision(List<Ball> balls)
        {
            foreach (Ball b in balls)
            {
                if (b == this) continue;

                if (base.ObjectBounds.Intersects(b.ObjectBounds))
                {
                    Rectangle myRect = base.ObjectBounds;
                    Rectangle BallRect = b.ObjectBounds;

                    if (BallRect.Center.X > myRect.Left && BallRect.Center.X < myRect.Right)
                    {
                        b.Speed.Y *= -1;
                        this.Speed.Y *= -1;
                    }
                    else if (BallRect.Center.Y > myRect.Top && BallRect.Center.Y < myRect.Bottom)
                    {
                        b.Speed.X *= -1;
                        this.Speed.X *= -1;
                    }
                    else
                    {
                        b.Speed *= -1;
                        this.Speed *= -1;
                    }
                }
            }
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
                if (BallLost != null)
                    BallLost(this, null);
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
