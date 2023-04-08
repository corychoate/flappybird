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
            List<Rectangle[]> allPipes = new List<Rectangle[]>();

            allPipes.Add(Pipes.buildPipes(rnd.Next(90, 710), 600));
            allPipes.Add(Pipes.buildPipes(rnd.Next(90, 710), 900));
            allPipes.Add(Pipes.buildPipes(rnd.Next(90, 710), 1200));
            allPipes.Add(Pipes.buildPipes(rnd.Next(90, 710), 1500));

            // move pipes
            Movement move = new Movement();

            // make bird fall, but jump when space is pressed
            bool spacePressed = false;
            bool canMove = true;
            double lastMoveTime = Raylib.GetTime();
            while (!Raylib.WindowShouldClose())
            {
                double currentTime = Raylib.GetTime();
                foreach (Rectangle[] pairOfPipes in allPipes)
                {
                    move.pipesMovement(pairOfPipes, 2, allPipes);
                }
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

                foreach (Rectangle[] pairOfPipes in allPipes)
                {
                    if (Raylib.CheckCollisionRecs(bird, pairOfPipes[0]) ||
                    Raylib.CheckCollisionRecs(bird, pairOfPipes[1]))
                    {
                        Raylib.EndDrawing();
                        break;
                    }
                }
                Raylib.BeginDrawing();

                // Background color
                Raylib.ClearBackground(Color.WHITE);

                // Create score at top left
                Raylib.DrawText("Score: ", 12, 12, 50, Color.BLACK);

                // Draw the bird
                Raylib.DrawRectangleRec(bird, Color.YELLOW);

                // Draw the pipes
                foreach (Rectangle[] pairOfPipes in allPipes)
                {
                    Raylib.DrawRectangleRec(pairOfPipes[0], Color.GREEN);
                    Raylib.DrawRectangleRec(pairOfPipes[1], Color.GREEN);
                }

                // End drawing
                Raylib.EndDrawing();
            }

            // Close window (moved outside the loop)
            Raylib.CloseWindow();
        }
    }
}