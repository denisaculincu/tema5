using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tema5
{
	class MutareHarta:Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Texture2D myGrid;
		MyObject myObject;
		OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"D:\\Denisa\\programare idk\\Tema5\\Tema5\\MutareHarta.accdb\"");

		public MutareHarta()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			myGrid = Content.Load<Texture2D>("grid");	
			myObject = new MyObject(con);
			myObject.texture = Content.Load<Texture2D>("object");
		}

		protected override void UnloadContent()
		{
			base.UnloadContent();
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				if (myObject.poz.X + myObject.texture.Width < myGrid.Width)
				{
					myObject.poz.X += 5;
					myObject.updateDB(con, 5, 0);
				}
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				if (myObject.poz.X > 0)
				{
					myObject.poz.X -= 5;
					myObject.updateDB(con, -5, 0);
				}
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Up))
			{
				if (myObject.poz.Y > 0)
				{
					myObject.poz.Y -= 5;
					myObject.updateDB(con, 0, -5);
				}
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Down))
			{
				if (myObject.poz.Y + myObject.texture.Height < myGrid.Height)
				{
					myObject.poz.Y += 5;
					myObject.updateDB(con, 0, 5);
				}
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();
			spriteBatch.Draw(myGrid, Vector2.Zero, Color.White);
			spriteBatch.Draw(myObject.texture, myObject.poz, Color.White);
			spriteBatch.End();
		}
	}
}
