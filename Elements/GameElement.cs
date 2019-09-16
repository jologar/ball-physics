using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameTest.Elements
{
    public class GameElement
    {
        public GameElement(Texture2D texture, Vector2 position) {
            this.Texture = texture;
            this.Position = position; 
        }
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
    }
}