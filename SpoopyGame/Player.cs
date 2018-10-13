using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;



namespace SpoopyGame
{
    class Player
    {
        public Texture2D PlayerTexture;
        public Vector2 Position;
        public bool Active;
        public int Health;
        public BoundingBox PlayerBoundingBox;
        public int Width {
            get { return PlayerTexture.Width; }
        }
        public int Height {
            get { return PlayerTexture.Height; }
        }

        public int HalfWidth {
            get { return PlayerTexture.Width / 2; }
        }

        public int HalfHeight {
            get { return PlayerTexture.Height / 2; }
        }

        public Vector3 MinBB(Vector2 position)
        {
            int minX = (int)Position.X - HalfWidth;
            int minY = (int)Position.Y - HalfHeight;
            Vector3 min = new Vector3(minX, minY, 0f);
            return min;
        }

        public Vector3 MaxBB(Vector2 position)
        {
            int maxX = (int)Position.X + HalfWidth;
            int maxY = (int)Position.Y + HalfHeight;
            Vector3 max = new Vector3(maxX, maxY, 0f);
            return max;
        }
        public void Initialize(Texture2D texture, Vector2 position)
        {
            PlayerTexture = texture;
            Position = position;
            PlayerBoundingBox = new BoundingBox(MinBB(Position), MaxBB(Position));
            Active = true;
            Health = 100;
            
        }

        public void Update()
        {
            PlayerBoundingBox.Min = MinBB(Position);
            PlayerBoundingBox.Max = MaxBB(Position);

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

    }
}