using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongMono
{
    public enum  PlayerTypes
    {
        Human,
        Computer
    }


    public class Paddle : Sprite
    {
        private readonly PlayerTypes _playerType;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds,PlayerTypes playerType) : base(texture, location,screenBounds)
      {
          _playerType = playerType;
      }


        public override void Update(GameTime gameTime,GameObjects gameObjects)
        {
            if(_playerType==PlayerTypes.Computer)
            {
                var random = new Random();
                var reactionThreshold = random.Next(50, 130);

                if (gameObjects.Ball.Location.Y + gameObjects.Ball.Height < Location.Y + reactionThreshold)
                {
                    Velocity = new Vector2(0, -7.5f);
                }
                if (gameObjects.Ball.Location.Y > Location.Y + Height + reactionThreshold)
                {
                    Velocity = new Vector2(0, 7.5f);
                }
            }

            if (_playerType == PlayerTypes.Human)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up) || gameObjects.TouchInput.Up)
                    Velocity = new Vector2(0, -8f);

                if (Keyboard.GetState().IsKeyDown(Keys.Down) || gameObjects.TouchInput.Down)
                    Velocity = new Vector2(0, 8f);
            }
            base.Update(gameTime,gameObjects);
        }

        protected override void CheckBounds()
        {
           Location.Y = MathHelper.Clamp(Location.Y, 0, _gameBoundaries.Height - _texture.Height);
        }
    }
}
