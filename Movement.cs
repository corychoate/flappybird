using System;
using Raylib_cs;

namespace flappybird
{
    public class Movement
    {
        Pipes pipeClass = new Pipes();
        public Movement()
        {
        }

        public void pipesMovement(Rectangle[] SpawnedPipes, int speed)
        {
            if (SpawnedPipes[0].x > -100 && SpawnedPipes[1].x > -100)
            {
                SpawnedPipes[0].x -= speed;
                SpawnedPipes[1].x -= speed;
            }
            else
            {
                pipeClass.resetPipe(SpawnedPipes);
            }
        }
    }
}
