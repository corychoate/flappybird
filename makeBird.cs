using System;
using Raylib_cs;

namespace flappybird
{
    static class makeBird
    {
        public static Rectangle GetBird()
        {
            //                  Top left:  X , Y || width, height
            Rectangle bird = new Rectangle(125, 400, 50, 50);
            Raylib.DrawRectangleRec(bird, Color.YELLOW);
            return bird;
        }
    }
}
