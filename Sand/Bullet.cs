﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sand
{
	public class Bullet : Entity
	{
		float speed;
		Vector2 direction;

		public Bullet(Vector2 position, float angle, bool from_first_player) : base(Engine.bullet_texture, position,false)
		{
			
			first_player = from_first_player;
			speed = 20f;
			rotation = angle;
			direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
		}

		public override void update(GameTime gametime)
		{
			position += direction * speed;
			base.update(gametime);
		}

		public override void draw(SpriteBatch sprite_batch) {
			if ((position.X < 0 | position.X > Engine.screen_width - texture.Width * Engine.scale.X) | (position.Y < 0 | position.Y > Engine.screen_height - texture.Height * Engine.scale.Y))
				Engine.entities.Remove(this);
			base.draw(sprite_batch);
		}
	}
}
