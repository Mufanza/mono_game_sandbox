using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameSandbox
{
    public class TestGame : Game
    {
        private Effect myShader;
        private Texture2D whiteRectangle;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public TestGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Create 300 * 200px white rectangle texture
            this.whiteRectangle = new Texture2D(this.GraphicsDevice, 300, 200);
            var flatRectangleData = new Color[300 * 200];
            Array.Fill(flatRectangleData, Color.White);
            this.whiteRectangle.SetData(flatRectangleData);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the shader
            this.myShader = Content.Load<Effect>("Shaders\\MyShader");

            // Case 1: Create texture
            var textureToSample     = new Texture2D(this.GraphicsDevice, 150, 100);
            var textureToSampleData = new Color[150 * 100];
            Array.Fill(textureToSampleData, Color.Red);
            textureToSample.SetData(textureToSampleData);

            // Case 2: Load Texture
            //var textureToSample = Content.Load<Texture2D>("Imgs\\wat");

            myShader.Parameters["MyTexture"].SetValue(textureToSample);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this._spriteBatch.Begin(effect: this.myShader);
            this._spriteBatch.Draw(this.whiteRectangle, new Rectangle(50, 50, 300, 200), Color.White);
            this._spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
