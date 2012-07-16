using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WarGame
{
    class Menu
    {
        static Texture2D Button, MenuText;
        static SpriteFont font;
        static int height, width;
        static Vector2 Place;

        public static void load(ContentManager Content, GraphicsDeviceManager graphics)
        {
            Button = Content.Load<Texture2D>("Button");
            MenuText = Content.Load<Texture2D>("MenuText");
            font = Content.Load<SpriteFont>("MenuFont");
            height = graphics.PreferredBackBufferHeight;
            width = graphics.PreferredBackBufferWidth;
            Place = new Vector2((width / 2) - (Button.Width / 2), (height / 2) - (Button.Height / 2));
        }

        public static void MenuDraw(SpriteBatch SpriteBatch){
            SpriteBatch.Draw(Button, Place, Color.White);
            SpriteBatch.Draw(MenuText, new Vector2(Place.X-40, Place.Y - 100), Color.White);
            SpriteBatch.DrawString(font, "Play", new Vector2(Place.X + (Button.Width / 4), Place.Y + 2), Color.White);
        }

        public static bool isMouseOnButton(MouseState mouse){
            Rectangle ButtonRec = new Rectangle((int)Place.X, (int)Place.Y, Button.Width, Button.Height);
            if (ButtonRec.Contains(mouse.X, mouse.Y))
            {
                return true;
            }
            return false;
        }
    }
}
