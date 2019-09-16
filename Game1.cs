using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameTest.Elements;

namespace MonogameTest
{
    public class Game1 : Game
    {
        const float PLAYER_SPEED = 100f;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameElement player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.player = new GameElement(
                this.Content.Load<Texture2D>("ball"), 
                new Vector2(
                    graphics.PreferredBackBufferWidth / 2,
                    graphics.PreferredBackBufferHeight / 2));         
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var dx = 0f;
            var dy = 0f;
            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up)) {
                dy = - PLAYER_SPEED * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Right)) {
                dx = PLAYER_SPEED * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down)) {
                dy = PLAYER_SPEED * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left)) {
                dx = - PLAYER_SPEED * (float) gameTime.ElapsedGameTime.TotalSeconds;
            }

            this.movePlayer(dx, dy);

            base.Update(gameTime);
        }

        private void movePlayer(float dx, float dy) {
            var maxX = this.graphics.PreferredBackBufferWidth - this.player.Width / 2;
            var maxY = this.graphics.PreferredBackBufferHeight - this.player.Height / 2;
            var newX = this.player.Position.X + dx;
            var newY = this.player.Position.Y + dy;
            if ((this.player.Width / 2 < newX) && (newX < maxX)) {
                this.player.Position.X += dx;
            }
            if ((this.player.Height / 2 < newY) && (newY < maxY)) {
                this.player.Position.Y += dy;
            }     
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(
                this.player.Texture, 
                this.player.Position, 
                null, 
                Color.White, 
                0f, 
                new Vector2(this.player.Width / 2, this.player.Height / 2), 
                Vector2.One,
                SpriteEffects.None,
                0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
