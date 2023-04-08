using System;
using Raylib_cs;

namespace flappybird
{
    class Pipes 
    {
        public static Rectangle[] buildPipes(int height)
        {
            int gap = 200;
            Random rnd = new Random();
            Rectangle[] pipes = new Rectangle[2];
            //            Top left:  X  , Y  ||       , width, height
            pipes[0] = new Rectangle(600, 0, 100, 800 - height - gap);
            // Bottom pipe
            pipes[1] = new Rectangle(600, 800 - height, 100, height);
            return pipes;
        }
        public void resetPipe(Rectangle[] SpawnedPipes)
        {
            int gap = 200;
            Random rnd = new Random();
            int height = rnd.Next(90, 710);
            SpawnedPipes[0].height = height;
            SpawnedPipes[1].height = height - gap;
            SpawnedPipes[1].y = 800 - height;
            SpawnedPipes[0].x = 600;
            SpawnedPipes[1].x = 600;
        }
    }
}