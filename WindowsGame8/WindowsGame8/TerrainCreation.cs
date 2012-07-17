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

        public static void loadContent(ContentManager Content)
        {
            terrain = new int[40, 20];
            Territory = Content.Load<Texture2D>("Territory");
            MakeTerrain();
        }

        public static void MakeTerrain()
        {
            Random rnd = new Random();
            int player = rnd.Next(3) + 1;
            int chanceToNewTerritory = 4;
            //שורה ראשונה
            for (int i = 0; i < terrain.GetLength(0); i++)
            {
                if(rnd.Next(chanceToNewTerritory) == 0)
                    player = rnd.Next(3) + 1;
                terrain[i, 0] = player;

            }

            //טור ראשון
            for (int j = 1; j < terrain.GetLength(1); j++)
            {
                if (rnd.Next(chanceToNewTerritory) == 0)
                    player = rnd.Next(3) + 1;
                terrain[0, j] = player;
            }

            //שאר המפה
            for (int i = 1; i < terrain.GetLength(0); i++)
            {
                for (int j = 1; j < terrain.GetLength(1); j++)
                {

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
