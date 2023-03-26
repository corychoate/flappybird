using System;
using Raylib_cs;

namespace flappybird
{
    static class Character
    {
        public static Rectangle GetBird()
        {
            Rectangle bird = new Rectangle(80, 400, 50, 50);
            Raylib.DrawRectangleRec(bird, Color.YELLOW);
            return bird;
        }
    }
}
