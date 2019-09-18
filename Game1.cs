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
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Physics physicsEngine;

        private Texture2D ballTexture;

        private MouseState previousMouseState;
        private GameElementsService elementsService;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.elementsService = new GameElementsService();
            this.physicsEngine = new Physics(this.elementsService);
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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var mouseState = Mouse.GetState();
            if (this.previousMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed) {
                // Add ball in position;
                var ball = new KineticElement();
                var position = new Vector2(mouseState.X, mouseState.Y);
                ball.Initialize(ballTexture, position);
                this.elementsService.AddKineticElement(ball);
                System.Console.WriteLine("Left click!");
            }
            this.previousMouseState = mouseState;

            this.physicsEngine.UpdateElements(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
            foreach (var element in this.elementsService.GameElements) {
                element.Draw(this.spriteBatch);
            }
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
