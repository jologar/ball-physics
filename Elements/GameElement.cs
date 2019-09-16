using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameTest.Elements
{
    public class GameElement
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Speed;
        public Vector2 Acceleration;

        public int Width 
        {
            get { return this.Texture.Width; }
        }

        public int Height
        {
            get { return this.Texture.Height; }
        }

        public void Initialize(Texture2D texture, Vector2 position) {
            this.Texture = texture;
            this.Position = position;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(
                this.Texture, 
                this.Position, 
                null, 
                Color.White, 
                0f, 
                new Vector2(this.Width / 2, this.Height / 2), 
                Vector2.One,
                SpriteEffects.None,
                0f);
        }
    }
}