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
    class TerrainCreation
    {
        static int[,] terrain;
        static Texture2D Territory;
        static int MaxSize = 10;
        public TerrainCreation()
        {
            
        }

        public static void loadContent(ContentManager Content, GraphicsDeviceManager graphics)
        {
            terrain = new int[graphics.PreferredBackBufferWidth / 15 / 2, graphics.PreferredBackBufferHeight / 15 / 2];
            Territory = Content.Load<Texture2D>("Territory");
            MakeTerrain();
        }

        public static void MakeTerrain()
        {
            Random rnd = new Random();
            for (int i = 0; i < terrain.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.GetLength(1); j++)
                {
                    int player = rnd.Next(3) + 1;
                    terrain[i,j] = player;
                }
            }
        }

        public void FindEmpty()
        {
            for (int i = 0; i < terrain.GetLength(0)-1; i++)
            {
                for (int j = 0; j < terrain.GetLength(1)-1; j++)
                {
                    if(terrain[i,j] == terrain
                }
            }
        }

        public static void drawBoard(SpriteBatch SpriteBatch)
        {
            Color color = Color.White;
            for (int i = 0; i < terrain.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.GetLength(1); j++)
                {
                    if (terrain[i, j] == 1)
                        color = Color.White;
                    else if (terrain[i, j] == 2)
                        color = Color.Blue;
                    else
                        color = Color.Red;

                    SpriteBatch.Draw(Territory, new Vector2(i*Territory.Width,j*Territory.Height), color);
                        
                }
            }
        }
    }
}
