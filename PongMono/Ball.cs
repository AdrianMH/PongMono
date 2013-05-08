using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongMono
{
    public class Ball : Sprite
    {
        private Paddle attachedToPaddle;

        public Ball(Texture2D texture, Vector2 location,Rectangle gameBoundaries) : base(texture, location,gameBoundaries)
        {

        }

        protected override void CheckBounds()
        {
            if (Location.Y>=(_gameBoundaries.Height - _texture.Height)||Location.Y<=0)
            {
                var newVelocity = new Vector2(Velocity.X, -Velocity.Y);
                Velocity = newVelocity;
            }
        }

        public override void Update(GameTime gameTime,GameObjects gameObjects)
        {
            if((Keyboard.GetState().IsKeyDown(Keys.Space) || gameObjects.TouchInput.Tapped) && attachedToPaddle!=null)
            {
                var newVelocity = new Vector2(10f, attachedToPaddle.Velocity.Y * .75f);
                Velocity = newVelocity;
                attachedToPaddle = null;
            }

            if (attachedToPaddle != null)
            {
                Location.X = attachedToPaddle.Location.X + attachedToPaddle.Width;
                Location.Y = attachedToPaddle.Location.Y;
            }
            else
            {
                if(BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox) || BoundingBox.Intersects(gameObjects.ComputerPaddle.BoundingBox))
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y);
                }
            }
            base.Update(gameTime,gameObjects);
        }


        public void AttachTo(Paddle paddle)
        {
            attachedToPaddle = paddle;
        }
    }
}