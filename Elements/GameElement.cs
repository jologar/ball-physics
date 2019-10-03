using Microsoft.Xna.Framework;

namespace MonogameTest.Elements
{
    public class GameElement
    {
        private Vector2 _position;
        public string TextureId;
        public Vector2 Position {
            get {return this._position;}
            set {
                this.CollisionBounds.X = (int) value.X;
                this.CollisionBounds.Y = (int) value.Y;
                this._position = value;
            }
        }
        public Rectangle CollisionBounds;
        public void Initialize(string textureId, Vector2 position, Rectangle elementShape) {
            this.TextureId = textureId;
            this.Position = position;
            this.CollisionBounds = elementShape;
            this.CollisionBounds.X = (int) position.X;
            this.CollisionBounds.Y = (int) position.Y;
        }
    }
}