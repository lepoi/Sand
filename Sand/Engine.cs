﻿using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sand
{
	public class Engine : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch sprite_batch;
		public static List<Entity> entities;
		public static Texture2D bullet_texture;
		public static Texture2D player_texture;

		public Engine()
		{
			graphics = new GraphicsDeviceManager (this);
			entities = new List<Entity>();

			Content.RootDirectory = "Content";
		}
			
		protected override void Initialize ()
		{
			
			// TODO: Add your initialization logic here
            
			base.Initialize ();
		}
			
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			sprite_batch = new SpriteBatch (GraphicsDevice);
			bullet_texture = Content.Load<Texture2D>("bullet");
			player_texture = Content.Load<Texture2D>("player");

			entities.Add(new Player(new Vector2(20, 20)));
			//TODO: use this.Content to load your game content here 
		}
			
		protected override void Update (GameTime gameTime)
		{
			foreach (Entity e in entities.ToArray())
			{
				e.update(gameTime);
			}
            
			base.Update (gameTime); 
		}
			
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(new Color(20, 20, 20));
			sprite_batch.Begin(SpriteSortMode.BackToFront);

			foreach (Entity e in entities.ToArray())
			{
				e.draw(sprite_batch);
			}
           	
			base.Draw (gameTime);
			sprite_batch.End();
		}
	}
}
