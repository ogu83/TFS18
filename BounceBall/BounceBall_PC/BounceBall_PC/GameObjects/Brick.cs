using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BounceBall.GameObjects
{
    public class Brick : SpriteObject
    {
        public event EventHandler BallCollided;

        public Brick()
        {
            base.Scale = 0.50F;
        }

        public Brick(Vector2 position)
            : this()
        {
            base.Position = position;
        }

        /// <summary>
        /// Checks the brick Collided with a Ball
        /// </summary>
        /// <param name="b">The Ball of the player</param>
        public void CheckCollision(Ball b)
        {
            if (base.ObjectBounds.Intersects(b.ObjectBounds))
            {
                Rectangle BrickRect = base.ObjectBounds;
                Rectangle BallRect = b.ObjectBounds;

                if (BallCollided != null)
                    BallCollided(this, null);

                if (BallRect.Center.X > BrickRect.Left && BallRect.Center.X < BrickRect.Right)
                    b.Speed.Y *= -1;
                else if (BallRect.Center.Y > BrickRect.Top && BallRect.Center.Y < BrickRect.Bottom)
                    b.Speed.X *= -1;
                else
                    b.Speed *= -1;
            }
        }
    }
}
