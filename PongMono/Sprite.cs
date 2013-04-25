using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongMono
{
    public abstract class Sprite
    {
        protected readonly Texture2D _texture;
        public Vector2 Location;
        protected readonly Rectangle _gameBoundaries;

        public int Width
        {
            get { return _texture.Width; }
        }
        public int Height
        {
            get { return _texture.Height; }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int) Location.X, (int) Location.Y, Width, Height);
            }
        }

        public Vector2 Velocity { get; protected set; }

        public Sprite(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
        {
            _texture = texture;
            Location = location;
            _gameBoundaries = gameBoundaries;
            Velocity = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime,GameObjects gameObjects)
        {
            Location += Velocity;

            CheckBounds();
        }

        protected abstract void CheckBounds();

    }
}