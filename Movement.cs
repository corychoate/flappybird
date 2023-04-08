using System;
using System.Collections.Generic;
using Raylib_cs;

namespace flappybird
{
    public class Movement
    {
        Pipes pipeClass = new Pipes();
        public Movement()
        {
        }

        public void pipesMovement(Rectangle[] SpawnedPipes, int speed, List<Rectangle[]> allPipes)
        {
            if (SpawnedPipes[0].x > -100 && SpawnedPipes[1].x > -100)
            {
                SpawnedPipes[0].x -= speed;
                SpawnedPipes[1].x -= speed;
            }
            else
            {
                for (int i = 0; i < allPipes.Count; i++)
                {
                    if (allPipes[i][0].x <= -100)
                    {
                        pipeClass.resetPipe(allPipes[i], allPipes);
                    }
                }
            }
        }
    }
}
