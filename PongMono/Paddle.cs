using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongMono
{

    public class Paddle : Sprite
    {
        private readonly Rectangle _screenBounds;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds) : base(texture, location)
        {
            _screenBounds = screenBounds;
        }

        

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Velocity = new Vector2(0, -8f);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Velocity = new Vector2(0, 8f);
            base.Update(gameTime);
        }

        protected override void CheckBounds()
        {
           Location.Y = MathHelper.Clamp(Location.Y, 0, _screenBounds.Height - _texture.Height);
        }
    }

    public abstract class Sprite
    {
        protected readonly Texture2D _texture;
        public Vector2 Location;
        public int Width
        {
            get { return _texture.Width; }
        }
        public int Height
        {
            get { return _texture.Height; }
        }

        public Vector2 Velocity { get; protected set; }

        public Sprite(Texture2D texture, Vector2 location)
        {
            _texture = texture;
            Location = location;
            Velocity = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            Location += Velocity;

            CheckBounds();
        }

        protected abstract void CheckBounds();

    }
}
