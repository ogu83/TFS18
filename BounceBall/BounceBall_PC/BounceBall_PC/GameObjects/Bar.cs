using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceBall.GameObjects
{
    public class Bar : SpriteObject
    {
        public Bar()
        {
            base.Position = Vector2.Zero;
            base.Scale = 0.5F;
            base.Speed = Vector2.One * 2;
        }

        internal override void Update(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            int MinX = 0;
            int MaxX = graphics.GraphicsDevice.Viewport.Width - ScaledWidth;

            if (Position.X + Speed.X < MaxX && Position.X + Speed.X >= MinX)
                Position.X += Speed.X;

            Position.Y = graphics.GraphicsDevice.Viewport.Height - ScaledHeight - 10;

            base.Update(graphics, gameTime);
        }

        public override Rectangle ObjectBounds
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, ScaledWidth, 1); }
        }
    }
}