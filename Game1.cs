using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameTest.Elements;
using System.Collections.Generic;

namespace MonogameTest
{
    public class Game1 : Game
    {
        const float PLAYER_SPEED = 100f;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private List<GameElement> elements = new List<GameElement>();

        private Texture2D ballTexture;

        private MouseState previousMouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.previousMouseState = Mouse.GetState();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ballTexture = this.Content.Load<Texture2D>("ball");
            // var ball = new GameElement();
            // ball.Initialize(
            //     this.Content.Load<Texture2D>("ball"),
            //     new Vector2(
            //         graphics.PreferredBackBufferWidth / 2,
            //         0));  

            // this.elements.Add(ball);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var mouseState = Mouse.GetState();
            if (this.previousMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed) {
                // Add ball in position;
                var ball = new GameElement();
                var position = new Vector2(mouseState.X, mouseState.Y);
                ball.Initialize(ballTexture, position);
                this.elements.Add(ball);
                System.Console.WriteLine("Left click!");
            }
            this.previousMouseState = mouseState;

            Physics.UpdateElements(this.elements, gameTime);

            base.Update(gameTime);
        }

        // private void movePlayer(float dx, float dy) {
            // var maxX = this.graphics.PreferredBackBufferWidth - this.ball.Width / 2;
            // var maxY = this.graphics.PreferredBackBufferHeight - this.ball.Height / 2;
            // var newX = this.ball.Position.X + dx;
            // var newY = this.ball.Position.Y + dy;
            // if ((this.ball.Width / 2 < newX) && (newX < maxX)) {
            //     this.ball.Position.X += dx;
            // }
            // if ((this.ball.Height / 2 < newY) && (newY < maxY)) {
            //     this.ball.Position.Y += dy;
            // }     
        // }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
            foreach (var element in this.elements) {
                element.Draw(this.spriteBatch);
            }
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
