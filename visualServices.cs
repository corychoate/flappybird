using System;
using System.Collections.Generic;
using Raylib_cs;

namespace flappybird;

// Creating the window for the game to fit inside of
public class visual
{
    public void window()
    {
        Raylib.InitWindow(500, 800, "Flappy Bird");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawText("Score: ", 12, 12, 50, Color.BLACK);
            //                text,    x,  y,  size,  color
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}