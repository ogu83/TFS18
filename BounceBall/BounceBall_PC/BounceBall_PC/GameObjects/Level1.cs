using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BounceBall.GameObjects
{
    public class Level1 : LevelBase
    {
        private int _brickStartX = 50;
        private int _brickStartY = 50;
        private int _brickWidth = 100;
        private int _brickHeight = 50;

        public Level1()
        {
            for (int j = 0; j < 6; j++)
                for (int i = 0; i < 7; i++)
                    this.Bricks.Add(new Brick(new Vector2(_brickStartX + i * _brickWidth, _brickStartY + j * _brickHeight)));
        }
    }
}
