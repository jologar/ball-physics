using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameTest.Elements
{
    public class GameElement
    {
        public string TextureId;
        public Vector2 Position;

        public void Initialize(string textureId, Vector2 position) {
            this.TextureId = textureId;
            this.Position = position;
        }
    }
}