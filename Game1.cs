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
        const string BALL_TEXTURE_ID = "ball";
        const string SURFACES_TEXTURE_ID = "surfaces";
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Physics physicsEngine;
        private Rectangle simpleGroundTextureRect;
        private MouseState previousMouseState;
        private GameElementsService elementsService;
        private Dictionary<string, Texture2D> texturesDictionary = new Dictionary<string, Texture2D>();
        private Dictionary<string, Texture2D> spriteMapDictionary = new Dictionary<string, Texture2D>();

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
            this.simpleGroundTextureRect = new Rectangle(192, 182, 48, 40);
             // Ground
            int groundTilesNum = this.graphics.PreferredBackBufferWidth / this.simpleGroundTextureRect.Width;
            if ((this.graphics.PreferredBackBufferWidth % this.simpleGroundTextureRect.Width) > 0) {
                groundTilesNum++;
            }
            Vector2 currentPosition = new Vector2(0, this.graphics.PreferredBackBufferHeight - this.simpleGroundTextureRect.Height);
            for (var i = 0; i < groundTilesNum; i++) {
                var ground = new GameElement();
                ground.Initialize(SURFACES_TEXTURE_ID, currentPosition);
                this.elementsService.GameElements.Add(ground);
                currentPosition.X += this.simpleGroundTextureRect.Width;
            }
            base.Initialize();
            System.Console.WriteLine("buffer height: {0}", this.graphics.PreferredBackBufferHeight);
            System.Console.WriteLine("texture height: {0}", this.simpleGroundTextureRect.Height);
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.texturesDictionary.Add(BALL_TEXTURE_ID, this.Content.Load<Texture2D>(BALL_TEXTURE_ID));
            this.spriteMapDictionary.Add(SURFACES_TEXTURE_ID, this.Content.Load<Texture2D>(SURFACES_TEXTURE_ID));
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
                ball.Initialize(BALL_TEXTURE_ID, position);
                this.elementsService.AddKineticElement(ball);
            }
            this.previousMouseState = mouseState;

            this.physicsEngine.UpdateElements(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.spriteBatch.Begin();
            // Draw elements
            foreach (var element in this.elementsService.GameElements) {
                if (this.texturesDictionary.ContainsKey(element.TextureId)) {
                    this.DrawTextureElement(element);
                } else if (this.spriteMapDictionary.ContainsKey(element.TextureId)) {
                    this.DrawSpriteMapElement(element, this.simpleGroundTextureRect);
                    
                }
            }
            this.spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawTextureElement(GameElement element) {
            Texture2D elementTexture = this.texturesDictionary[element.TextureId];
            this.spriteBatch.Draw(
                elementTexture, 
                element.Position, 
                null, 
                Color.White, 
                0f, 
                new Vector2(elementTexture.Width / 2, elementTexture.Height / 2), 
                Vector2.One,
                SpriteEffects.None,
                0f);
        }

        private void DrawSpriteMapElement(GameElement element, Rectangle sourceRectangle) {
            Texture2D spriteMap = this.spriteMapDictionary[element.TextureId];
            this.spriteBatch.Draw(
                spriteMap,
                element.Position,
                sourceRectangle,
                Color.White,
                0f,
                Vector2.Zero,
                Vector2.One,
                SpriteEffects.None,
                0f);
        }
    }
}
