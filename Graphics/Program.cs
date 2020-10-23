using System.Numerics;
using System;
using Raylib_cs;
using System.Threading;
using System.Collections.Generic;

namespace Graphics
{
    class Buller
    {
        public Vector2 speed = new Vector2();

        public float bulletX;
         public float bulletY;

    }
    class Timer
    {
        public int maxValue;
        public int currentValue;

        public Timer(int v)
        {
            maxValue = currentValue = v;
        }

        public void Tick()
        {
            currentValue--;
            currentValue = Math.Max(currentValue, 0);
        }

        public void Reset()
        {
            currentValue = maxValue;
        }

    }

    class Enemy
    {
        public Vector2 position = new Vector2();

        private Random generator = new Random();

        private Timer t;
        

        public Enemy()
        {
            t = new Timer(60);
            position.X = generator.Next(1700);
        }

        public void Update()
        {
            t.Tick();
            if (t.currentValue == 0)
            {
                position.Y = position.Y += 15f;
                t.Reset();
            }
       
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            int WindowW = 1920;
            int WindowH = 1080;
            Raylib.InitWindow(WindowW, WindowH, "poggers");

            List<Enemy> enemies = new List<Enemy>();

            float x = 800;
            float y = 790;
            

            

            Raylib.SetTargetFPS(60);


            Timer t = new Timer(60);


            var bruh = Raylib.LoadImage(@"C:\Users\axel.lilja2\Documents\PROG02\Graphics\Graphics\bin\Debug\netcoreapp3.1\boomer.png");
            Texture2D texture = Raylib.LoadTextureFromImage(bruh);


            while (!Raylib.WindowShouldClose())
            {
                t.Tick();


                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    x += 5.5f;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    x -= 5.5f;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    y -= 3.5f;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    if (y <= (800))
                    {
                        y += 3.5f;
                    }
                }
                 if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                    {
                        
                    }
                Raylib.BeginDrawing();


                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawTexture(texture, (int)x, (int)y, Color.WHITE);





                foreach (Enemy e in enemies)
                {
                    e.Update();

                    Raylib.DrawRectangle(
                      (int)(e.position.X),
                      (int)(e.position.Y),
                      40,
                      40,
                      Color.RED
                    );
                }

                if (t.currentValue == 0)
                {
                    enemies.Add(new Enemy());

                    // DO whatever
                    t.Reset();
                }




                Raylib.EndDrawing();

            }


        }
    }
}
