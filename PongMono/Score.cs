using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongMono
{
    public class Score
    {
        
        private readonly Rectangle _gameBoundaries;

        public int PlayerScore { get; set; }
        public int ComputerScore { get; set; }

        public Score( Rectangle gameBoundaries)
        {
            
            _gameBoundaries = gameBoundaries;
        }

        public void Draw(SpriteFont spriteBatch)
        {
            
        }

        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (gameObjects.Ball.Location.X + gameObjects.Ball.Width < 0)
            {
                ComputerScore++;
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);
            }

            if(gameObjects.Ball.Location.X > _gameBoundaries.Width)
            {
                PlayerScore++;
                gameObjects.Ball.AttachTo(gameObjects.ComputerPaddle);
            }
        }
    }
}