using System;
using System.Collections.Generic;
using Raylib_cs;

namespace flappybird
{

    public class visual
    {

        public void window()
        {
            Random rnd = new Random();
            Raylib.InitWindow(600, 800, "Flappy Bird");
            Raylib.SetTargetFPS(60);

            //draw bird
            Rectangle bird = makeBird.GetBird();

            // draw pipes

            Rectangle[] pipes = Pipes.buildPipes(rnd.Next(90, 710));

            // move pipes
            Movement move = new Movement();

            // make bird fall, but jump when space is pressed
            bool spacePressed = false;
            bool canMove = true;
            double lastMoveTime = Raylib.GetTime();
            while (!Raylib.WindowShouldClose())
            {
                double currentTime = Raylib.GetTime();
                move.pipesMovement(pipes, 2);

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                {
                    spacePressed = true;
                }
                // Gives the bounce affect up if they hit the bottom
                if (bird.y >= 750)
                {
                    bird.y = 720;
                    canMove = false;
                    lastMoveTime = currentTime;
                }
                // This stops the user from going above the roof
                if (bird.y <= 45)
                {
                    canMove = false;
                    lastMoveTime = currentTime;

                }

                if (Raylib.IsKeyReleased(KeyboardKey.KEY_SPACE))
                {
                    spacePressed = false;
                }

                if (spacePressed && canMove)
                {
                    bird.y -= 60;
                    lastMoveTime = currentTime;
                    canMove = false;
                }

                if (!canMove && (currentTime - lastMoveTime) * 1000 >= 200)
                {
                    canMove = true;
                }

                if (!spacePressed)
                {
                    bird.y += 1;
                }
                if (Raylib.CheckCollisionRecs(bird, pipes[0]) ||
                    Raylib.CheckCollisionRecs(bird, pipes[1]))
                {
                    Raylib.EndDrawing();
                    break;
                }

                Raylib.BeginDrawing();

                //backround color
                Raylib.ClearBackground(Color.WHITE);

                //create score at top left
                //                text,    x,  y,  size,  color
                Raylib.DrawText("Score: ", 12, 12, 50, Color.BLACK);

                //draw the bird
                Raylib.DrawRectangleRec(bird, Color.YELLOW);

                //draw the pipes
                Raylib.DrawRectangleRec(pipes[0], Color.GREEN);
                Raylib.DrawRectangleRec(pipes[1], Color.GREEN);

                //the exit button ends the game
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}