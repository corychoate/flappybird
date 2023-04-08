using System;
using System.Collections.Generic;
using Raylib_cs;

namespace flappybird
{
    class Pipes 
    {
        Random rnd = new Random();
        public static Rectangle[] buildPipes(int height, int xspawn)
        {
            int gap = 200;
            Random rnd = new Random();
            Rectangle[] pipes = new Rectangle[2];
            //            Top left:  X  , Y  ||       , width, height
            pipes[0] = new Rectangle(xspawn, 0, 100, 800 - height - gap);
            // Bottom pipe
            pipes[1] = new Rectangle(xspawn, 800 - height, 100, height);
            return pipes;
        }
        public void resetPipe(Rectangle[] SpawnedPipes, List<Rectangle[]> allPipes)
        {
            int gap = 200;
            int height = rnd.Next(90, 710);
            SpawnedPipes[0].height = height;
            SpawnedPipes[1].height = height - gap;
            SpawnedPipes[1].y = 800 - height;

            int i = allPipes.IndexOf(SpawnedPipes);

            if (i >= 0 && i < allPipes.Count)
            {
                if (i == 0)
                {
                    SpawnedPipes[0].x = allPipes[allPipes.Count - 1][0].x + 200;
                    SpawnedPipes[1].x = allPipes[allPipes.Count - 1][1].x + 200;
                }
                else
                {
                    SpawnedPipes[0].x = allPipes[i - 1][0].x + 200;
                    SpawnedPipes[1].x = allPipes[i - 1][1].x + 200;
                }
            }
        }

    }
}